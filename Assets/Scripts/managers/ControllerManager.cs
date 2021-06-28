using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public sealed class ControllerManager : Singleton<ControllerManager>
{
    public enum DeviceOption
    {
        rightController,
        leftController
    }

    public enum ButtonOption
    {
        triggerButton,
        gripButton,
        primaryButton,
        primaryTouch,
        secondaryButton,
        secondaryTouch,
        thumbstickClick,
        thumbstickTouch,
    }

    static readonly Dictionary<DeviceOption, InputDeviceCharacteristics> deviceOptionDict = 
        new Dictionary<DeviceOption, InputDeviceCharacteristics>
        {
            {DeviceOption.leftController, InputDeviceCharacteristics.Left | InputDeviceCharacteristics.HeldInHand },
            {DeviceOption.rightController, InputDeviceCharacteristics.Right | InputDeviceCharacteristics.HeldInHand }
        };
    static readonly Dictionary<ButtonOption, InputFeatureUsage<bool>> buttonOptionDict =
        new Dictionary<ButtonOption, InputFeatureUsage<bool>>
        {
            {ButtonOption.triggerButton, CommonUsages.triggerButton },
            {ButtonOption.gripButton, CommonUsages.gripButton },
            {ButtonOption.primaryButton, CommonUsages.primaryButton },
            {ButtonOption.primaryTouch, CommonUsages.primaryTouch },
            {ButtonOption.secondaryButton, CommonUsages.secondaryButton },
            {ButtonOption.secondaryTouch, CommonUsages.secondaryTouch },
            {ButtonOption.thumbstickClick, CommonUsages.primary2DAxisClick },
            {ButtonOption.thumbstickTouch, CommonUsages.primary2DAxisTouch }
        };

    private ConcurrentDictionary<(DeviceOption, ButtonOption), (bool current, bool last)> prevDict =
                new ConcurrentDictionary<(DeviceOption, ButtonOption), (bool current, bool last)>();
    private ConcurrentDictionary<(DeviceOption, ButtonOption), (bool current, bool last)> fixedPrevDict =
            new ConcurrentDictionary<(DeviceOption, ButtonOption), (bool current, bool last)>();

    List<InputDevice> inputDevices = new List<InputDevice>();

    protected override void Awake()
    {
        base.Awake();

        try
        {
            foreach (ButtonOption option in Enum.GetValues(typeof(ButtonOption)))
            {
                Debug.Log("[ControllerManager] add devices loop " + option);
                prevDict.TryAdd((DeviceOption.leftController, option), (false, false));
                prevDict.TryAdd((DeviceOption.rightController, option), (false, false));
                fixedPrevDict.TryAdd((DeviceOption.leftController, option), (false, false));
                fixedPrevDict.TryAdd((DeviceOption.rightController, option), (false, false));
            }

        }
        catch(Exception e)
        {
            Debug.LogError("[ControllerManager] could not start\n" + e.Message);
        }

        Debug.Log("[ControllerManager] startup finished");
    }

    #region UIMethods

    public bool getButtonPressing(DeviceOption device, ButtonOption button)
    {
        return prevDict[(device, button)].current;
    }

    public bool getButtonPress(DeviceOption device, ButtonOption button)
    {
        if (prevDict[(device, button)].current && !prevDict[(device, button)].last)
        {
            return true;
        }
        return false;
    }

    public bool getButtonRelease(DeviceOption device, ButtonOption button)
    {
        if (!prevDict[(device, button)].current && prevDict[(device, button)].last)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        foreach (ButtonOption option in Enum.GetValues(typeof(ButtonOption)))
        {
            (bool current, bool last) newStateRight =
                (findButtonPressing(DeviceOption.rightController, option), prevDict[(DeviceOption.rightController, option)].current);
            prevDict[(DeviceOption.rightController, option)] = newStateRight;
            (bool current, bool last) newStateLeft =
                (findButtonPressing(DeviceOption.leftController, option), prevDict[(DeviceOption.leftController, option)].current);
            prevDict[(DeviceOption.leftController, option)] = newStateLeft;
        }
    }

    #endregion

    #region PhysicsMethods
    public bool getFixedButtonPressing(DeviceOption device, ButtonOption button)
    {
        return fixedPrevDict[(device, button)].current;
    }

    public bool getFixedButtonPress(DeviceOption device, ButtonOption button)
    {
        if (fixedPrevDict[(device, button)].current && !fixedPrevDict[(device, button)].last)
        {
            return true;
        }
        return false;
    }

    public bool getFixedButtonRelease(DeviceOption device, ButtonOption button)
    {
        if (!fixedPrevDict[(device, button)].current && fixedPrevDict[(device, button)].last)
        {
            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        foreach (ButtonOption option in Enum.GetValues(typeof(ButtonOption)))
        {
            (bool current, bool last) newStateRight =
                (findButtonPressing(DeviceOption.rightController, option), fixedPrevDict[(DeviceOption.rightController, option)].current);
            fixedPrevDict[(DeviceOption.rightController, option)] = newStateRight;
            (bool current, bool last) newStateLeft =
                (findButtonPressing(DeviceOption.leftController, option), fixedPrevDict[(DeviceOption.leftController, option)].current);
            fixedPrevDict[(DeviceOption.leftController, option)] = newStateLeft;
        }
    }

    #endregion

    private bool findButtonPressing(DeviceOption device, ButtonOption button)
    {
        bool inputValue = false;

        InputDevices.GetDevicesWithCharacteristics(deviceOptionDict[device], inputDevices);

        if (inputDevices.Count == 0 || !inputDevices[0].TryGetFeatureValue(buttonOptionDict[button], out inputValue))
        {
            //Debug.LogError("unity - input device not found: " + inputDevices[0].name + " : " + inputDevices[0].characteristics);
        }

        return inputValue;
    }
}

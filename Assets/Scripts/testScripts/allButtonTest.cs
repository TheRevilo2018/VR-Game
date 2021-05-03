using System;
using UnityEngine;
using UnityEngine.XR;

public class allButtonTest : MonoBehaviour
{
    public bool testing = false;
    // Update is called once per frame
    private void Update()
    {
        if (testing)
        {
            Debug.Log("testing - regular loop");
            try
            {
                foreach (ControllerManager.ButtonOption button in
                    Enum.GetValues(typeof(ControllerManager.ButtonOption)))
                {
                    if (ControllerManager.Instance.getButtonPressing(ControllerManager.DeviceOption.leftController, button))
                    {
                        Debug.Log("testing - left " + button.ToString() + " regular pressed");
                    }
                    if (ControllerManager.Instance.getButtonPressing(ControllerManager.DeviceOption.rightController, button))
                    {
                        Debug.Log("testing - right " + button.ToString() + " regular pressed");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogError("testing - " + e);
            }

        }
    }

    private void FixedUpdate()
    {
        if (testing)
        {
            Debug.Log("testing - fixed loop");
            try
            {
                foreach (ControllerManager.ButtonOption button in
                    Enum.GetValues(typeof(ControllerManager.ButtonOption)))
                {
                    if (ControllerManager.Instance.getFixedButtonPressing(ControllerManager.DeviceOption.leftController, button))
                    {
                        Debug.Log("testing - left " + button.ToString() + " regular pressed");
                    }
                    if (ControllerManager.Instance.getFixedButtonPressing(ControllerManager.DeviceOption.rightController, button))
                    {
                        Debug.Log("testing - right " + button.ToString() + " regular pressed");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogError("testing - " + e);
            }
        }
    }
}

using System;
using UnityEngine;

public class grabVR : MonoBehaviour
{
    public enum messages
    {
        parentGrab,
        holdingChange,
        parentLetGo,
        parentPress,
        parentRelease
    };

    public float grabRadius = 0.2f;
    public LayerMask grabLayer;
    public ControllerManager.DeviceOption hand;

    GameObject holdingTarget;
    grabbableObject grabbedObject;
    bool castMode = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        try
        {
            //when grabbed
            if (ControllerManager.Instance.getFixedButtonPress(hand, ControllerManager.ButtonOption.gripButton))
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius, grabLayer);

                if (colliders.Length > 0)
                {
                    holdingTarget = colliders[0].gameObject;
                    grabbedObject = holdingTarget.GetComponent<grabbableObject>();
                    grabbedObject.grab(transform);
                }
            }

            //when started using
            if (grabbedObject != null && ControllerManager.Instance.getFixedButtonPress(hand, ControllerManager.ButtonOption.triggerButton))
            {
                grabbedObject.startUsing();
            }

            //when stopped using
            if (grabbedObject != null && ControllerManager.Instance.getFixedButtonRelease(hand, ControllerManager.ButtonOption.triggerButton))
            {
                grabbedObject.stopUsing();
            }

            //when dropped
            if (ControllerManager.Instance.getFixedButtonRelease(hand, ControllerManager.ButtonOption.gripButton))
            {
                grabbedObject.drop();
                holdingTarget = null;
                grabbedObject = null;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    void changeMode((bool mode, Vector3 location) tup)
    {
        castMode = tup.mode;
    }
}

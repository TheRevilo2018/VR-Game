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
    public float maxAngularVelocity = 20f;

    Rigidbody holdingTarget;
    bool castMode = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        //if hand is open
        if (!ControllerManager.Instance.getFixedButtonPressing(hand, ControllerManager.ButtonOption.gripButton)
            || holdingTarget == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius, grabLayer);
            if (colliders.Length > 0)
            {
                holdingTarget = colliders[0].attachedRigidbody;
                SendMessage(messages.holdingChange.ToString(), true, SendMessageOptions.DontRequireReceiver);
            }
            else if (holdingTarget != null)
            {
                Debug.Log("unity - before send");
                holdingTarget.SendMessage(messages.parentLetGo.ToString(), SendMessageOptions.DontRequireReceiver);
                Debug.Log("unity - mid send");
                holdingTarget = null;
                SendMessage(messages.holdingChange.ToString(), false, SendMessageOptions.DontRequireReceiver);
                Debug.Log("unity - end speed");
            }
        }
        else
        {
            if (holdingTarget)
            {
                //snap the object to the player's hand
                holdingTarget.velocity = (transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;

                //adjust angular velocity to rotate to hand
                holdingTarget.maxAngularVelocity = maxAngularVelocity;
                Quaternion deltaRot = transform.rotation * Quaternion.Inverse(holdingTarget.transform.rotation);
                Vector3 eulerRot = new Vector3(Mathf.DeltaAngle(0, deltaRot.eulerAngles.x),
                    Mathf.DeltaAngle(0, deltaRot.eulerAngles.y), Mathf.DeltaAngle(0, deltaRot.eulerAngles.z));
                eulerRot *= 0.95f;
                eulerRot *= Mathf.Deg2Rad;
                holdingTarget.angularVelocity = eulerRot / Time.fixedDeltaTime;

                use();
                holdingTarget.SendMessage(messages.parentGrab.ToString(), SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void changeMode((bool mode, Vector3 location) tup)
    {
        castMode = tup.mode;
    }



    void use()
    {
        if (!castMode)
        {
            if (ControllerManager.Instance.getFixedButtonPress(hand, ControllerManager.ButtonOption.triggerButton))
            {
                holdingTarget.SendMessage(messages.parentPress.ToString(), SendMessageOptions.DontRequireReceiver);
            }
            if (ControllerManager.Instance.getFixedButtonRelease(hand, ControllerManager.ButtonOption.triggerButton))
            {
                holdingTarget.SendMessage(messages.parentRelease.ToString(), SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class grabbableObject : MonoBehaviour
{
    private Transform location;
    private Transform parentLoc;
    private Rigidbody body;
    public float maxAngularVelocity = 20f;

    protected virtual void Awake()
    {
        location = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = maxAngularVelocity;
        gameObject.layer += LayerMask.NameToLayer("Grabbable");
    }

    protected void FixedUpdate()
    {
        if (parentLoc != null)
        {
            //snap the object to the player's hand
            body.velocity = (parentLoc.position - location.position) / Time.fixedDeltaTime;

            //adjust angular velocity to rotate to hand
            Quaternion deltaRot = parentLoc.rotation * Quaternion.Inverse(location.rotation);
            Vector3 eulerRot = new Vector3(Mathf.DeltaAngle(0, deltaRot.eulerAngles.x),
                Mathf.DeltaAngle(0, deltaRot.eulerAngles.y), Mathf.DeltaAngle(0, deltaRot.eulerAngles.z));
            eulerRot *= 0.95f;
            eulerRot *= Mathf.Deg2Rad;
            body.angularVelocity = eulerRot / Time.fixedDeltaTime;
        }
    }

    public abstract void startUsing();
    public abstract void stopUsing();

    public virtual void grab(Transform parent)
    {
        parentLoc = parent;
    }
    public virtual void drop()
    {
        parentLoc = null;
    }
}

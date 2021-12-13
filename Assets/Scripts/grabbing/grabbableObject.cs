using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class grabbableObject : MonoBehaviour
{
    protected Transform location;
    protected Transform parentLoc;
    protected Rigidbody body;
    public float maxAngularVelocity = 20f;

    public UnityEvent<grabbableObject> dropEvent;
    public UnityEvent<grabbableObject> grabEvent;

    public bool Held
    {
        get;
        protected set;
    }

    protected virtual void Awake()
    {
        location = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = maxAngularVelocity;
        gameObject.layer = LayerMask.NameToLayer("Grabbable");
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

    public virtual void startUsing()
    {
        //do nothing
    }
    public virtual void stopUsing()
    {
        //do nothing
    }

    public virtual void grab(Transform parent = null)
    {
        grabEvent.Invoke(this);
        parentLoc = parent;
        Held = true;
    }

    public virtual void drop()
    {
        dropEvent.Invoke(this);
        parentLoc = null;
        Held = false;
    }
}

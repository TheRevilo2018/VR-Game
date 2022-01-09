using UnityEngine;
using UnityEngine.Events;

public class Grabbable : MonoBehaviour, IGrabbable
{
    protected Transform location;
    protected Transform parentLoc;
    protected Rigidbody body;
    public float maxAngularVelocity = 20f;

    public UnityEvent<IGrabbable> DropEvent { get; protected set; }
    public UnityEvent<IGrabbable> GrabEvent { get; protected set; }

    public bool Held
    {
        get;
        protected set;
    }

    protected virtual void Awake()
    {
        DropEvent = new UnityEvent<IGrabbable>();
        GrabEvent = new UnityEvent<IGrabbable>();

        location = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = maxAngularVelocity;
        gameObject.layer += LayerMask.NameToLayer("Interactable");
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

    public virtual void grab(Transform parent = null)
    {
        parentLoc = parent;
        Held = true;
        GrabEvent.Invoke(this);
    }

    public virtual void drop()
    {
        parentLoc = null;
        Held = false;
        DropEvent.Invoke(this);
    }
}

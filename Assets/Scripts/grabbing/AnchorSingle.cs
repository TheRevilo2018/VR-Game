using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSingle<T> : MonoBehaviour where T : AnchorableObject
{
    #region Properties
    public T Contains
    {
        get;
        private set;
    }

    public bool Full
    {
        get
        {
            return Contains != null;
        }
    }

    #endregion

    protected virtual void Start()
    {
        gameObject.layer += LayerMask.NameToLayer("Anchor");
        Contains = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        T grabbable;
        if (other.TryGetComponent(out grabbable))
        {
            grabbable.dropEvent.AddListener(objectDropped);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        T grabbable;
        if (other.TryGetComponent(out grabbable))
        {
            grabbable.dropEvent.RemoveListener(objectDropped);
        }
    }

    public virtual void objectDropped(grabbableObject input)
    {
        if (Contains == null && input is T)
        {
            T thing = (T)input;

            if (spellValid(thing))
            {
                Rigidbody body = thing.gameObject.GetComponent<Rigidbody>();

                thing.dropEvent.RemoveListener(objectDropped);
                thing.grabEvent.AddListener(objectGrabbed);
                Contains = thing;
                thing.transform.SetParent(transform);
                thing.transform.localPosition = new Vector3(0, 0, 0);
                body.velocity = new Vector3(0, 0, 0);
                body.isKinematic = true;
            }
        }

    }

    public virtual void objectGrabbed(grabbableObject thing)
    {
        thing.dropEvent.AddListener(objectDropped);
        thing.grabEvent.RemoveListener(objectGrabbed);
        Contains = null;
        thing.transform.SetParent(null);
        thing.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    protected virtual bool spellValid(T thing)
    {
        return true;
    }
}

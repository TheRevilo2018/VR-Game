using UnityEngine;

public class AnchorSingle: MonoBehaviour
{
    #region Properties
    public Anchorable Contains
    {
        get;
        private set;
    }

    public bool Full
    {
        get { return Contains != null; }
    }

    #endregion

    protected virtual void Start()
    {
        Contains = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter " + other.name);
        Anchorable anchorable;
        if (other.TryGetComponent(out anchorable))
        {
            Debug.Log("Found anchorable " + other.name);
            anchorable.AttachRequestEvent.AddListener(AttachObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Anchorable anchorable;
        if (other.TryGetComponent(out anchorable))
        {
            anchorable.AttachRequestEvent.RemoveListener(AttachObject);
        }
    }

    public virtual void AttachObject(Anchorable input)
    {
        Debug.Log("Attach request results: " + !Full + " " + anchorableInput(input));
        if (!Full && anchorableInput(input))
        {
            Rigidbody body = input.gameObject.GetComponent<Rigidbody>();

            input.AttachRequestEvent.RemoveListener(AttachObject);
            input.DetachRequestEvent.AddListener(detachObject);
            Contains = input;
            input.transform.SetParent(transform);
            input.transform.localPosition = new Vector3(0, 0, 0);
            body.velocity = new Vector3(0, 0, 0);
            body.isKinematic = true;
        }

    }

    public virtual void detachObject(Anchorable thing)
    {
        thing.AttachRequestEvent.AddListener(AttachObject);
        thing.DetachRequestEvent.RemoveListener(detachObject);
        Contains = null;
        thing.transform.SetParent(null);
        thing.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    protected virtual bool anchorableInput(Anchorable input)
    {
        return true;
    }
}

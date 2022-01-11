using UnityEngine;

public class SnapAnchorObject : MonoBehaviour
{
    public Transform homeAnchor;
    public Grabbable Grab { get; protected set; } = null;
    public bool Held { get; protected set; }

    protected virtual void Start()
    {
        Grabbable installGrabbable;
        if (gameObject.TryGetComponent(out installGrabbable))
        {
            Grab = installGrabbable;
        }
        else
        {
            Grab = gameObject.AddComponent<Grabbable>();
        }

        Grab.DropEvent.AddListener(drop);
    }

    private void drop(IGrabbable grab)
    {
        transform.position = homeAnchor.position;
        transform.rotation = homeAnchor.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Held = false;
    }
}

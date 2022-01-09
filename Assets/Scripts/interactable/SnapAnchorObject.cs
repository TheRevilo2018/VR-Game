using UnityEngine;

public class SnapAnchorObject : MonoBehaviour
{
    public Transform homeAnchor;
    public Grabbable Grab { get; protected set; }
    public bool Held { get; protected set; }

    private void Start()
    {
        Grab.DropEvent.AddListener(drop);
    }

    private void drop(IGrabbable grab)
    {
        transform.position = homeAnchor.position;
        transform.rotation = homeAnchor.rotation;
        Held = false;
    }
}

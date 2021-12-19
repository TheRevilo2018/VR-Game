using UnityEngine;

public class SnapAnchorObject : MonoBehaviour
{
    public Transform homeAnchor;
    public Grabbable Grab { get; protected set; }
    public bool Held { get; protected set; }

    private void Start()
    {
        Grab.dropEvent.AddListener(drop);
    }

    private void drop(Grabbable grab)
    {
        transform.position = homeAnchor.position;
        transform.rotation = homeAnchor.rotation;
        Held = false;
    }
}

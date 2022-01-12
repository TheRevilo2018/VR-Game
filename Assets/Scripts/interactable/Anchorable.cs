using UnityEngine;
using UnityEngine.Events;

public class Anchorable : MonoBehaviour
{
    public bool Attached { get; set; } = false;

    public UnityEvent<Anchorable> AttachRequestEvent { get; protected set; } = new UnityEvent<Anchorable>();
    public UnityEvent<Anchorable> DetachRequestEvent { get; protected set; } = new UnityEvent<Anchorable>();

    public virtual void tryAttach()
    {
        Debug.Log("attach event called");
        if (!Attached)
        {
            AttachRequestEvent.Invoke(this);
        }
    }

    public virtual void tryDetach()
    {
        DetachRequestEvent.Invoke(this);
    }
}

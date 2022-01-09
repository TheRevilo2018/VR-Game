using UnityEngine;
using UnityEngine.Events;

public class Anchorable : MonoBehaviour
{
    public bool Attched { get; protected set; }

    public UnityEvent<Anchorable> attachEvent = new UnityEvent<Anchorable>();
    public UnityEvent<Anchorable> detachEvent = new UnityEvent<Anchorable>();

    public virtual void attach()
    {
        Attched = true;
        attachEvent.Invoke(this);
    }

    public virtual void detach()
    {
        Attched = false;
        detachEvent.Invoke(this);
    }
}

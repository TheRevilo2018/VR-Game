using UnityEngine;
using UnityEngine.Events;

public class Anchorable : MonoBehaviour
{
    public UnityEvent<Anchorable> attachEvent;
    public UnityEvent<Anchorable> detachEvent;

    public virtual void attach()
    {
        attachEvent.Invoke(this);
    }

    public virtual void dettach()
    {
        detachEvent.Invoke(this);
    }
}

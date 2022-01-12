using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Usable : MonoBehaviour
{
    public UnityEvent<Usable> StartUsingEvent { get; protected set; } = new UnityEvent<Usable>();
    public UnityEvent<Usable> StopUsingEvent { get; protected set; } = new UnityEvent<Usable>();

    public bool CurrentlyUsing { get; private set; } = false;

    public virtual void startUsing()
    {
        CurrentlyUsing = true;
        StartUsingEvent.Invoke(this);
    }
    public virtual void stopUsing()
    {
        CurrentlyUsing = false;
        StopUsingEvent.Invoke(this);
    }
}

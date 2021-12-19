using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Usable : MonoBehaviour
{
    public UnityEvent<Usable> startUsingEvent = new UnityEvent<Usable>();
    public UnityEvent<Usable> stopUsingEvent = new UnityEvent<Usable>();

    public bool CurrentlyUsing { get; private set; } = false;

    public virtual void startUsing()
    {
        CurrentlyUsing = true;
        startUsingEvent.Invoke(this);
    }
    public virtual void stopUsing()
    {
        CurrentlyUsing = false;
        stopUsingEvent.Invoke(this);
    }
}

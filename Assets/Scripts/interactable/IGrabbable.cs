using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IGrabbable
{
    public UnityEvent<IGrabbable> DropEvent { get; }
    public UnityEvent<IGrabbable> GrabEvent { get; }

    public bool Held { get;}

    public void grab(Transform parent = null);
    public void drop();
}

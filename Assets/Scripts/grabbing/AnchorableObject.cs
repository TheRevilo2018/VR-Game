using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorableObject : grabbableObject
{
    public bool Anchored
    {
        get;
        private set;
    }

    protected override void Awake()
    {
        base.Awake();
        gameObject.layer = LayerMask.NameToLayer("Anchorable");
    }
}

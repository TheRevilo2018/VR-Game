using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapAnchorObject : grabbableObject
{
    public Transform homeAnchor;

    public override void drop()
    {
        parentLoc = homeAnchor;
        Held = false;
    }
}

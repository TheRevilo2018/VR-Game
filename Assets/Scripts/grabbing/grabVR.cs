using System;
using UnityEngine;

public class grabVR : MonoBehaviour
{
    public float grabRadius = 0.2f;
    public LayerMask grabLayer;
    public Transform handLoc;

    GameObject holdingTarget;
    grabbableObject grabbedObject;

    public bool Holding
    {
        get
        {
            return holdingTarget != null;
        }
    }


    public void grab()
    {
        Collider[] colliders = Physics.OverlapSphere(handLoc.position, grabRadius, grabLayer);

        if (colliders.Length > 0)
        {
            holdingTarget = colliders[0].gameObject;
            grabbedObject = holdingTarget.GetComponent<grabbableObject>();
            grabbedObject.grab(handLoc);
        }
    }

    public void startUsing()
    {
        if(grabbedObject != null)
        {
            grabbedObject.startUsing();
        }
    }

    public void stopUsing()
    {
        if (grabbedObject != null)
        {
            grabbedObject.stopUsing();
        }
    }

    public void drop()
    {
        if (grabbedObject != null)
        {
            grabbedObject.drop();
            holdingTarget = null;
            grabbedObject = null;
        }
    }
}

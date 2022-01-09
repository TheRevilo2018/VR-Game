using System;
using UnityEngine;

public class GrabVR : MonoBehaviour
{
    public float grabRadius = 0.2f;
    public LayerMask grabLayer;
    public Transform handLoc;

    GameObject holdingTarget;
    IGrabbable grabbedObject;
    Usable usableObject;

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
            grabbedObject = holdingTarget.GetComponent<IGrabbable>();
            usableObject = holdingTarget.GetComponent<Usable>();
            grabbedObject.grab(handLoc);
        }
    }

    public void startUsing()
    {
        if(usableObject != null)
        {
            usableObject.startUsing();
        }
    }

    public void stopUsing()
    {
        if (usableObject != null)
        {
            usableObject.stopUsing();
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

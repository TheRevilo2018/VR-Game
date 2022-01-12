using System.Collections.Generic;
using UnityEngine;

public class GrabVR : MonoBehaviour
{
    public float grabRadius = 0.2f;
    //public LayerMask layerMask;
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

    private void Start()
    {
        Debug.LogWarning("[GrabVR] - This grabs objects in every layer");
    }

    //TODO - figure out how to properly apply layers to this
    public void grab()
    {
        Collider[] colliders = Physics.OverlapSphere(handLoc.position, grabRadius/*, layerMask*/);
        int i = 0;

        while (colliders.Length > i && !Holding)
        {
            IGrabbable tempGrab;
            if (colliders[i].gameObject.TryGetComponent(out tempGrab))
            {
                holdingTarget = colliders[i].gameObject;
                grabbedObject = tempGrab;
                usableObject = holdingTarget.GetComponent<Usable>();
                grabbedObject.grab(handLoc);
            }

            i++;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMany : MonoBehaviour
{
    public bool replace;
    public int maxAnchored;
    List<GameObject> anchoredObjects;

    SphereCollider anchorCollider;
    Transform anchorPoint;

    protected void Start()
    {
        anchorPoint = gameObject.GetComponent<Transform>();
        anchorCollider = gameObject.GetComponent<SphereCollider>();
        anchoredObjects = new List<GameObject>();
    }


    bool tryAddObject(GameObject newItem)
    {
        bool returnVal = false;

        if (anchoredObjects.Count <= maxAnchored || maxAnchored < 0)
        {
            anchoredObjects.Add(newItem);
            returnVal = true;
        }
        else if (replace)
        {
            anchoredObjects.RemoveAt(0);
            anchoredObjects.Add(newItem);
            returnVal = true;
        }
        else
        {
            returnVal = false;
        }


        return returnVal;
    }

    bool tryRemoveObject(GameObject removeItem)
    {
        bool returnVal = false;

        if (anchoredObjects.Remove(removeItem))
        {
            returnVal = true;
        }

        return returnVal;
    }
}

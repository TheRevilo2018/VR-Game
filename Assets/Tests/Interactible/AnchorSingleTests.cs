using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AnchorSingleTests
{
    [UnityTest]
    public IEnumerator CreatedCorrectly()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<AnchorSingle>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator grabReleaseOneFrameCheckHold()
    {
        //create the grabVR object and start it moving
        GameObject anchorObject = new GameObject();
        anchorObject.name = "anchor";
        AnchorSingle testGrab = anchorObject.AddComponent<AnchorSingle>();

        //create the IGrabbable
        GameObject anchorableObject = new GameObject();
        anchorableObject.name = "anchorable";
        anchorableObject.layer = 8; //Interactible
        Anchorable testAnchorable = anchorableObject.AddComponent<Anchorable>();
        SphereCollider anchorableCollider = anchorableObject.AddComponent<SphereCollider>();
        Rigidbody testRB = anchorableObject.AddComponent<Rigidbody>();
        testRB.useGravity = true;

        yield return null;

        //testStuff
        int preGrab = 0;
        int postGrab = 0;
        int preDrop = 0;
        int postDrop = 0;

        anchorableCollider.radius = 1;

        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0)
            {
                if (testAnchorable.transform.position == anchorObject.transform.position) preGrab++;
                testGrab.AttachObject(testAnchorable);
                if (testAnchorable.transform.position == anchorObject.transform.position) postGrab++;
            }
            else
            {
                if (testAnchorable.transform.position == anchorObject.transform.position) preDrop++;
                testGrab.detachObject(testAnchorable);
                if (testAnchorable.transform.position == anchorObject.transform.position) postDrop++;
            }

            yield return null;
        }

        Assert.Greater(preGrab, 0);
        Assert.Greater(postGrab, 0);
        Assert.AreEqual(50, preDrop);
        Assert.Greater(postDrop, 0);
    }

    [UnityTest]
    public IEnumerator checkEventSubscription()
    {
        //create the grabVR object and start it moving
        GameObject anchorObject = new GameObject("anchor");
        AnchorSingle testAnchor = anchorObject.AddComponent<AnchorSingle>();
        SphereCollider anchorCol = anchorObject.AddComponent<SphereCollider>();
        anchorCol.isTrigger = true;

        //create the IGrabbable
        GameObject anchorableObject = new GameObject("anchorable");
        anchorableObject.transform.position = new Vector3(4, 0, 0);
        anchorableObject.layer = 8; //Interactible
        Anchorable testAnchorable = anchorableObject.AddComponent<Anchorable>();
        SphereCollider anchorableCollider = anchorableObject.AddComponent<SphereCollider>();
        Rigidbody testRB = anchorableObject.AddComponent<Rigidbody>();
        testRB.useGravity = false;

        yield return null;

        anchorableCollider.radius = 1;

        int anchoredCount = 0;

        for (int i = 0; i < 100; i++)
        {
            Debug.Log("loop number: " + i + " anchorObject position: " + anchorObject.transform.position 
                                        + " anchorable possition: " + anchorableObject.transform.position);
            if (!testAnchorable.Attached)
            {
                testRB.velocity = new Vector3(-10, 0, 0);
            }
            if (i % 2 == 0)
            {
                testAnchorable.tryAttach();
            }
            else
            {
                testAnchorable.tryDetach();
            }

            if (testAnchor.Full) anchoredCount++;

            yield return null;
        }

        Assert.Greater(anchoredCount, 0);
    }
}

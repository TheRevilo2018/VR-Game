using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

public class GrabTests
{
    class FakeGrabbable : MonoBehaviour, IGrabbable
    {
        public UnityEvent<IGrabbable> DropEvent { get; protected set; }
        public UnityEvent<IGrabbable> GrabEvent { get; protected set; }
        public bool Held { get; protected set; }

        private void Start()
        {
            DropEvent = new UnityEvent<IGrabbable>();
            GrabEvent = new UnityEvent<IGrabbable>();
        }

        public void drop()
        {
            Held = false;
            DropEvent.Invoke(this);
        }

        public void grab(Transform parent = null)
        {
            Held = true;
            GrabEvent.Invoke(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("grabbable collision");
        }
    }




    [UnityTest]
    public IEnumerator CreatedCorrectly()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<GrabVR>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator grabReleaseOneFrameCheckHold()
    {
        //create the grabVR object and start it moving
        GameObject grabberObject = new GameObject();
        grabberObject.name = "grabber";
        GrabVR testGrab = grabberObject.AddComponent<GrabVR>();
        testGrab.handLoc = testGrab.transform;
        Rigidbody testRB = grabberObject.AddComponent<Rigidbody>();
        testRB.useGravity = false;

        //create the IGrabbable
        GameObject grabbableObject = new GameObject();
        grabbableObject.name = "grabbable";
        grabbableObject.layer =  8; //Interactible
        FakeGrabbable testGrabbable = grabbableObject.AddComponent<FakeGrabbable>();
        SphereCollider grabbableCollider = grabbableObject.AddComponent<SphereCollider>();

        yield return null;

        //testStuff
        int preGrab = 0;
        int postGrab = 0;
        int preDrop = 0;
        int postDrop = 0;

        grabbableCollider.radius = 1;

        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0)
            {
                if (testGrabbable.Held) preGrab++;
                testGrab.grab();
                if (testGrabbable.Held) postGrab++;
            }
            else
            {
                if (testGrabbable.Held) preDrop++;
                testGrab.drop();
                if (testGrabbable.Held) postDrop++;
            }

            yield return null;
        }

        Assert.AreEqual(0, preGrab);
        Assert.AreEqual(50, postGrab);
        Assert.AreEqual(50, preDrop);
        Assert.AreEqual(0, postDrop);
    }

    //[UnityTest]
    //public IEnumerator CorrectLayerMask()
    //{
    //    //create the grabVR object and start it moving
    //    GameObject grabberObject = new GameObject();
    //    grabberObject.name = "grabber";
    //    GrabVR testGrab = grabberObject.AddComponent<GrabVR>();
    //    testGrab.handLoc = testGrab.transform;
    //    testGrab.layerMask = LayerMask.NameToLayer("Interactable");
    //    Rigidbody testRB = grabberObject.AddComponent<Rigidbody>();
    //    testRB.useGravity = false;

    //    yield return null;

    //    Assert.AreEqual(8, testGrab.layerMask.value);
    //}
}

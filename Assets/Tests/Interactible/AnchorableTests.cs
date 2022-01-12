using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AnchorableTests
{
    [UnityTest]
    public IEnumerator CreatedCorrectly()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<Anchorable>();

        yield return null;
    }

    //not a helpful test anymore
    //[UnityTest]
    //public IEnumerator CheckAttachedProperty()
    //{
    //    GameObject testObject = new GameObject();
    //    testObject.AddComponent<Anchorable>();
    //    Anchorable anchorable = testObject.GetComponent<Anchorable>();

    //    yield return null;

    //    Assert.IsFalse(anchorable.Attached);
    //    anchorable.tryAttach();
    //    Assert.IsFalse(anchorable.Attached);
    //    anchorable.tryDetach();
    //    Assert.IsFalse(anchorable.Attached);

    //    yield return null;
    //}

    [UnityTest]
    public IEnumerator CheckAnchorableEvents()
    {
        List<bool> startEvents = new List<bool>();
        List<bool> stopEvents = new List<bool>();
        GameObject testObject = new GameObject();
        testObject.AddComponent<Anchorable>();
        Anchorable anchorable = testObject.GetComponent<Anchorable>();

        //the reciver over the event has to notify the anchorable when it got attached and when it didn't
        anchorable.AttachRequestEvent.AddListener(delegate (Anchorable e)
        {
            e.Attached = true;
            startEvents.Add(e.Attached);
        });
        anchorable.DetachRequestEvent.AddListener(delegate (Anchorable e)
        {
            e.Attached = false;
            stopEvents.Add(e.Attached);
        });
        yield return null;

        anchorable.tryAttach();
        yield return null;

        anchorable.tryDetach();
        yield return null;

        anchorable.tryDetach();
        yield return null;

        anchorable.tryAttach();
        anchorable.tryDetach();

        yield return null;

        List<bool> correctStartEvents = new List<bool>() { true, true };
        List<bool> correctStopEvents = new List<bool>() { false, false, false};

        Assert.AreEqual(correctStartEvents, startEvents);
        Assert.AreEqual(correctStopEvents, stopEvents);
    }
}

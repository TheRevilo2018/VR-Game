using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GrabbableTests
{
    [UnityTest]
    public IEnumerator CreatedCorrectly()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<Rigidbody>();
        testObject.AddComponent<Grabbable>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckUsingProperty()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<Rigidbody>();
        testObject.AddComponent<Grabbable>();
        Grabbable usable = testObject.GetComponent<Grabbable>();

        yield return null;

        Assert.IsFalse(usable.Held);
        usable.grab();
        Assert.IsTrue(usable.Held);
        usable.drop();
        Assert.IsFalse(usable.Held);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckUsingEvents()
    {
        List<bool> startEvents = new List<bool>();
        List<bool> stopEvents = new List<bool>();

        GameObject testObject = new GameObject();
        testObject.AddComponent<Rigidbody>();
        testObject.AddComponent<Grabbable>();
        Grabbable usable = testObject.GetComponent<Grabbable>();

        usable.GrabEvent.AddListener(delegate (IGrabbable e)
        {
            startEvents.Add(e.Held);
        });
        usable.DropEvent.AddListener(delegate (IGrabbable e)
        {
            stopEvents.Add(e.Held);
        });
        yield return null;

        usable.grab();
        yield return null;

        usable.drop();
        yield return null;

        usable.drop();
        yield return null;

        usable.grab();
        usable.drop();

        yield return null;

        List<bool> correctStartEvents = new List<bool>() { true, true };
        List<bool> correctStopEvents = new List<bool>() { false, false, false };

        Assert.AreEqual(correctStartEvents, startEvents);
        Assert.AreEqual(correctStopEvents, stopEvents);
    }
}

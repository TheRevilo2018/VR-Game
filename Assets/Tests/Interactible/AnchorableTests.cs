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

    [UnityTest]
    public IEnumerator CheckUsingProperty()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<Anchorable>();
        Anchorable usable = testObject.GetComponent<Anchorable>();

        yield return null;

        Assert.IsFalse(usable.Attched);
        usable.attach();
        Assert.IsTrue(usable.Attched);
        usable.detach();
        Assert.IsFalse(usable.Attched);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckUsingEvents()
    {
        List<bool> startEvents = new List<bool>();
        List<bool> stopEvents = new List<bool>();
        GameObject testObject = new GameObject();
        testObject.AddComponent<Anchorable>();
        Anchorable usable = testObject.GetComponent<Anchorable>();

        usable.attachEvent.AddListener(delegate (Anchorable e)
        {
            startEvents.Add(e.Attched);
        });
        usable.detachEvent.AddListener(delegate (Anchorable e)
        {
            stopEvents.Add(e.Attched);
        });
        yield return null;

        usable.attach();
        yield return null;

        usable.detach();
        yield return null;

        usable.detach();
        yield return null;

        usable.attach();
        usable.detach();

        yield return null;

        List<bool> correctStartEvents = new List<bool>() { true, true };
        List<bool> correctStopEvents = new List<bool>() { false, false, false };

        Assert.AreEqual(correctStartEvents, startEvents);
        Assert.AreEqual(correctStopEvents, stopEvents);
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UsableTests
{
    [UnityTest]
    public IEnumerator CreatedCorrectly()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<Usable>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckUsingProperty()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<Usable>();
        Usable usable = testObject.GetComponent<Usable>();

        yield return null;

        Assert.IsFalse(usable.CurrentlyUsing);
        usable.startUsing();
        Assert.IsTrue(usable.CurrentlyUsing);
        usable.stopUsing();
        Assert.IsFalse(usable.CurrentlyUsing);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckUsingEvents()
    {
        List<bool> startEvents = new List<bool>();
        List<bool> stopEvents = new List<bool>();
        GameObject testObject = new GameObject();
        testObject.AddComponent<Usable>();
        Usable usable = testObject.GetComponent<Usable>();

        usable.StartUsingEvent.AddListener(delegate (Usable e)
        {
            startEvents.Add(e.CurrentlyUsing);
        });
        usable.StopUsingEvent.AddListener(delegate (Usable e)
        {
            stopEvents.Add(e.CurrentlyUsing);
        });
        yield return null;

        usable.startUsing();
        yield return null;

        usable.stopUsing();
        yield return null;

        usable.stopUsing();
        yield return null;

        usable.startUsing();
        usable.stopUsing();

        yield return null;

        List<bool> correctStartEvents = new List<bool>() { true, true };
        List<bool> correctStopEvents = new List<bool>() { false, false, false };

        Assert.AreEqual(correctStartEvents, startEvents);
        Assert.AreEqual(correctStopEvents, stopEvents);
    }
}

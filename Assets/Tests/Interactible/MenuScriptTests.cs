using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MenuScriptTests
{
    [UnityTest]
    public IEnumerator CreatedCorrectlyAddedUseClass()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<MenuScript>();
        testObject.AddComponent<Rigidbody>();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        yield return null;

        Assert.IsTrue(testObject.TryGetComponent<Usable>(out _));
    }
}

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class SnapAnchorTests : MonoBehaviour
{
    [UnityTest]
    public IEnumerator CreatedCorrectlyAddedGrabbableClass()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<SnapAnchorObject>();
        testObject.AddComponent<Rigidbody>();
        testObject.AddComponent<SphereCollider>();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        yield return null;

        Assert.IsTrue(testObject.TryGetComponent<Grabbable>(out _));
    }

    [UnityTest]
    public IEnumerator CreatedCorrectlyStoredExistingGrabbableClass()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<SnapAnchorObject>();
        testObject.AddComponent<Rigidbody>();
        Grabbable expected = testObject.AddComponent<Grabbable>();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        yield return null;

        Grabbable[] grabList = testObject.GetComponents<Grabbable>();
        Grabbable actual = grabList[0];
        Assert.AreEqual(1, grabList.Length);
        Assert.AreEqual(expected, actual);
    }
}

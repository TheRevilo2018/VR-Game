using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class GrabTests
{
    [UnityTest]
    public IEnumerator CreatedCorrectly()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<GrabVR>();

        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpellParentTest
{
    class TestSpellParent : SpellParent
    {

    }

    [UnityTest]
    public IEnumerator SpellParentCreateWithNoObjectsPredeclared()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<TestSpellParent>();
        testObject.AddComponent<Rigidbody>();

        yield return null;

        Assert.IsTrue(testObject.TryGetComponent<Grabbable>(out _));
        Assert.IsTrue(testObject.TryGetComponent<Anchorable>(out _));
        Assert.IsTrue(testObject.TryGetComponent<Usable>(out _));
    }

    [UnityTest]
    public IEnumerator SpellParentCreateWithAllObjectsPredeclared()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<TestSpellParent>();
        testObject.AddComponent<Rigidbody>();
        Grabbable grab1 = testObject.AddComponent<Grabbable>();
        Usable use1 = testObject.AddComponent<Usable>();
        Anchorable anchor1 = testObject.AddComponent<Anchorable>();

        yield return null;

        Grabbable grab2;
        Usable use2;
        Anchorable anchor2;

        Assert.IsTrue(testObject.TryGetComponent(out grab2));
        Assert.IsTrue(testObject.TryGetComponent(out anchor2));
        Assert.IsTrue(testObject.TryGetComponent(out use2));

        Assert.AreEqual(grab1, grab2); 
        Assert.AreEqual(use1, use2);
        Assert.AreEqual(anchor1, anchor2);
    }

    [UnityTest]
    public IEnumerator SpellParentCreateWithNoObjectsTestProperties()
    {
        GameObject testObject = new GameObject();
        TestSpellParent testParent = testObject.AddComponent<TestSpellParent>();
        testObject.AddComponent<Rigidbody>();

        yield return null;

        Assert.NotNull(testParent.GrabbableScript);
        Assert.NotNull(testParent.UsableScript);
        Assert.NotNull(testParent.AnchorableScript);
    }

    [UnityTest]
    public IEnumerator SpellParentCreateWithAllObjectsTestProperties()
    {
        GameObject testObject = new GameObject();
        TestSpellParent testParent = testObject.AddComponent<TestSpellParent>();
        testObject.AddComponent<Rigidbody>();
        Grabbable grab1 = testObject.AddComponent<Grabbable>();
        Usable use1 = testObject.AddComponent<Usable>();
        Anchorable anchor1 = testObject.AddComponent<Anchorable>();

        yield return null;

        Assert.AreEqual(grab1, testParent.GrabbableScript);
        Assert.AreEqual(use1, testParent.UsableScript);
        Assert.AreEqual(anchor1, testParent.AnchorableScript);
    }
}

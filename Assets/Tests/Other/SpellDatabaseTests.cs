using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class SpellDatabaseTests
{
    [UnityTest]
    public IEnumerator SpellDatabaseGetTestSpell()
    {
        GameObject testObject = new GameObject();
        SpellDatabase dataBase = testObject.AddComponent<SpellDatabase>();
        dataBase.baseElement = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Objects/Spells/Basic/ElementBase.prefab");
        
        Element element = ScriptableObject.CreateInstance<Element>();
        element.name = "testName";
        dataBase.elements = new List<Element> { element};

        yield return null;

        GameObject testSpell = SpellDatabase.Instance.getSpellInstance("testName", testObject.transform);

        yield return null;

        Assert.IsNotNull(testSpell);
        Assert.IsTrue(testSpell.TryGetComponent<Rigidbody>(out _));
        Assert.IsTrue(testSpell.TryGetComponent<Collider>(out _));
        Assert.IsTrue(testSpell.TryGetComponent<ElementBaseScript>(out _));
        Assert.IsTrue(testSpell.TryGetComponent<Grabbable>(out _));
    }
}

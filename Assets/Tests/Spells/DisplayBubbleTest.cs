using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class BubbleDisplayTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CreatedWithEverythingNullSprite()
    {
        GameObject testObject = new GameObject();
        GameObject testCamera = new GameObject();

        testObject.AddComponent<SpriteRenderer>();
        testObject.AddComponent<BubbleDisplay>();
        BubbleDisplay testDisplay = testObject.GetComponent<BubbleDisplay>();
        testDisplay.cameraLocation = testCamera.transform;

        yield return null;
    }

    //TODO - don't know how to make sure this throws an exception.
    /*[UnityTest]
    public IEnumerator CreatedWithoutSpriteRendererOnObject()
    {
        GameObject testObject = new GameObject();
        GameObject testCamera = new GameObject();

        testObject.AddComponent<BubbleDisplay>();
        BubbleDisplay testDisplay = testObject.GetComponent<BubbleDisplay>();

        testDisplay.cameraLocation = testCamera.transform;

        yield return null;
    }*/

    [UnityTest]
    public IEnumerator CreatedWithoutSpriteRendererInScript()
    {
        GameObject testObject = new GameObject();
        GameObject testCamera = new GameObject();

        testObject.AddComponent<SpriteRenderer>();
        testObject.AddComponent<BubbleDisplay>();
        BubbleDisplay testDisplay = testObject.GetComponent<BubbleDisplay>();

        testDisplay.cameraLocation = testCamera.transform;

        yield return null;
    }
}

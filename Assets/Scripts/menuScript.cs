using UnityEngine;

public class menuScript : MonoBehaviour
{
    public string sceneName;

    void parentGrab()
    {
        //TODO may need to become a coroutine
        SceneController.Instance.loadNewScene(sceneName);
    }
}

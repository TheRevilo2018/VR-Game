using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneControlerHelper : MonoBehaviour
{
    public string starterScene;
    void Start()
    {
        SceneController.Instance.addScene(starterScene);
    }
}

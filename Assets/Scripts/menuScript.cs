using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : SnapAnchorObject
{
    public string targetScene;
    public string playerScene;

    private bool used = false;
    private bool finished = false;

    public override void startUsing()
    {
        if(!used)
        {
            Scene currentScene = gameObject.scene;
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(playerScene));

            GameManager.Instance.UnloadScene(currentScene.name);

            //TODO may need to become a coroutine
            GameManager.Instance.LoadScene(targetScene);
            finished = true;
        }
    }

    private void Update()
    {
        if(finished)
        {
            Destroy(gameObject);
        }
    }
}

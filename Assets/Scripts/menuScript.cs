using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : grabbableObject
{
    public string targetScene;
    public string playerScene;

    private bool used = false;
    private bool finished = false;

    public override void grab(Transform parent)
    {
        base.grab(parent);
        //show target location
    }

    public override void drop()
    {
        base.drop();
        //do nothing
    }

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

    public override void stopUsing()
    {
        //do nothing
    }

    private void Update()
    {
        if(finished)
        {
            Destroy(gameObject);
        }
    }
}

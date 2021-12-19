using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : SnapAnchorObject
{
    public Usable Use { get; protected set; }

    public string targetScene;
    public string playerScene;

    private bool used = false;
    private bool finished = false;

    private void Start()
    {
        Usable tempUsable;
        if (gameObject.TryGetComponent(out tempUsable))
        {
            Use = tempUsable;
        }
        else
        {
            Use = gameObject.AddComponent<Usable>();
        }
        Use.startUsingEvent.AddListener(startUsing);
    }

    public void startUsing(Usable use)
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

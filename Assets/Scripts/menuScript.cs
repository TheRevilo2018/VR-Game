using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : SnapAnchorObject
{
    public Usable Use { get; protected set; }

    public string targetScene;
    public string playerScene;

    private bool used = false;
    private bool finished = false;

    protected override void Start()
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

        base.Start();
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
        Debug.Log("[MenuScript] start - layer: " + gameObject.layer);
        if (finished)
        {
            Destroy(gameObject);
        }
    }
}

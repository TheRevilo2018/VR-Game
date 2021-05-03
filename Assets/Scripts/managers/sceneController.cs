using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//TODO figure out how to do this with coroutines
public sealed class SceneController
{
    private static SceneController _instance;
    private static readonly object padlock = new object();
    public static SceneController Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                    _instance = new SceneController();
                return _instance;
            }
        }
    }


    private bool isLoading = false;
    public bool IsLoading
    {
        get
        {
            return isLoading;
        }
    }

    public UnityEvent onLoadBegin;
    public UnityEvent onLoadEnd;

    private SceneController()
    {
        Debug.Log("unity - SceneController started");
        SceneManager.sceneLoaded += setActiveScene;
        Debug.Log("unity - SceneController startup finished");
    }

    public void loadNewScene(string sceneName)
    {
        if(!isLoading)
        {
            isLoading = true;
            onLoadBegin?.Invoke();
            unloadScene(SceneManager.GetActiveScene().name);

            loadScene(sceneName);
            onLoadEnd?.Invoke();
            isLoading = false;
        }
    }

    public void addScene(string sceneName, bool active = true)
    {
        if (!isLoading)
        {
            isLoading = true;
            onLoadBegin?.Invoke();

            loadScene(sceneName);
            onLoadEnd?.Invoke();
            isLoading = false;
        }
    }

    void loadScene(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    void unloadScene(string sceneName)
    {
        AsyncOperation op = SceneManager.UnloadSceneAsync(sceneName);
    }

    void setActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}

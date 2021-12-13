using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private string _currentSceneName = string.Empty;

    List<AsyncOperation> _loadOperations;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _loadOperations = new List<AsyncOperation>();

        LoadScene("MainMenu");
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            //transition between scene stuff
        }
        Debug.Log("[GameManager] scene load complete");
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("[GameManager] scene unload complete");
    }

    public void LoadScene(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        if (ao == null)
        {
            Debug.LogError("[GameManager] could not load scene: " + sceneName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentSceneName = sceneName;
    }

    public void UnloadScene(string sceneName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(sceneName);

        if (ao == null)
        {
            Debug.LogError("[GameManger] could not unload scene: " + sceneName);
            return;
        }

        ao.completed += OnUnloadOperationComplete;
    }

}

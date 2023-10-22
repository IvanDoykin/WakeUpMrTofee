using Eflatun.SceneReference;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Action UnloadingHasStarted;
    public Action UnloadingHasFinished;

    public Action LoadingHasStarted;
    public Action LoadingHasFinished;

    [SerializeField] private Music _music;

    [SerializeField] private SceneReference _mainMenu;

    private bool _firstLoading = true;
    private Scene _loadedScene;

    public void LoadLevel(SceneReference scene)
    {
        StartCoroutine(Load(scene.BuildIndex));
    }

    public void ReloadLevel()
    {
        StartCoroutine(Load(_loadedScene.buildIndex));
    }

    public void LoadMenu()
    {
        StartCoroutine(Load(_mainMenu.BuildIndex));
    }

    private IEnumerator Load(int buildIndex)
    {
        if (!_firstLoading)
        {
            UnloadingHasStarted?.Invoke();

            var unloading = SceneManager.UnloadSceneAsync(_loadedScene);
            while (!unloading.isDone)
            {
                yield return null;
            }

            UnloadingHasFinished?.Invoke();
        }

        LoadingHasStarted?.Invoke();

        var loading = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        while (!loading.isDone)
        {
            yield return null;
        }

        _loadedScene = SceneManager.GetSceneAt(1);
        LoadingHasFinished?.Invoke();

        if (_firstLoading)
        {
            _firstLoading = false;
        }
    }
}

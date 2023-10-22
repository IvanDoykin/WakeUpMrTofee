using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private Music _music;

    private void Awake()
    {
        _loader.LoadMenu();
        _music.PlayDefaultMusic();
    }
}

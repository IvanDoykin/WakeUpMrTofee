using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; }

    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _winMusic;
    private float _defaultMusicLastTime = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetVolume(float newVolume)
    {
        _music.volume = newVolume;
        PlayerPrefs.SetFloat("Volume_music", newVolume);
    }

    [ContextMenu("Default")]
    public void PlayDefaultMusic()
    {
        if (_music.clip != _defaultMusic)
        {
            _music.clip = _defaultMusic;
            _music.time = _defaultMusicLastTime;
            _music.loop = true;
            _music.Play();
        }
    }

    [ContextMenu("Win")]
    public void PlayWinMusic()
    {
        _defaultMusicLastTime = _music.time;
        _music.time = 0f;
        _music.loop = false;
        _music.clip = _winMusic;
        _music.Play();
    }
}

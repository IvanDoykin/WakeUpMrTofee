using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _winMusic;
    private float _defaultMusicLastTime = 0f;

    [ContextMenu("Default")]
    public void PlayDefaultMusic()
    {
        if (_music.clip != _defaultMusic)
        {
            _music.clip = _defaultMusic;
            _music.time = _defaultMusicLastTime;
            _music.volume = 0.5f;
            _music.loop = true;
            _music.Play();
        }
    }

    [ContextMenu("Win")]
    public void PlayWinMusic()
    {
        _defaultMusicLastTime = _music.time;
        _music.time = 0f;
        _music.volume = 1f;
        _music.loop = false;
        _music.clip = _winMusic;
        _music.Play();
    }
}

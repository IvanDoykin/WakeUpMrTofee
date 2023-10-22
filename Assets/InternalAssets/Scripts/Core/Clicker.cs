using System.Collections;
using System.Collections.Generic;
using UIModule;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public static Clicker Instance { get; private set; }

    private AudioSource _click;

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

        _click = GetComponent<AudioSource>();
        CustomButton.HasClicked += () => _click.Play();
    }

    public void SetVolume(float newVolume)
    {
        _click.volume = newVolume;
        PlayerPrefs.SetFloat("Volume_clicker", newVolume);
    }
}

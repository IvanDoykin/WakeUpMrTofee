using System.Collections;
using System.Collections.Generic;
using UIModule;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private AudioSource _click;

    private void Awake()
    {
        _click = GetComponent<AudioSource>();
        CustomButton.HasClicked += () => _click.Play();
    }
}

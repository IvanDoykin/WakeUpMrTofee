using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _lightColor;
    [SerializeField] private Color _darkColor;

    public virtual void MakeLighter()
    {
        _image.color = _lightColor;
    }

    public virtual void MakeDarker()
    {
        _image.color = _darkColor;
    }
}

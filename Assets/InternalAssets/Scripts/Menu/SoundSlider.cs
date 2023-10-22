using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public Action<float> SliderChanged;

    public void Initialize(float sliderValue)
    {
        GetComponent<Slider>().value = sliderValue;
    }

    public void OnChangedSlider(Single sliderValue)
    {
        SliderChanged?.Invoke(sliderValue);
    }
}

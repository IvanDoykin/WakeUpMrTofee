using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private SoundSlider _audioSlider;
    [SerializeField] private SoundSlider _musicSlider;

    public void Initialize()
    {
        _audioSlider.SliderChanged += Clicker.Instance.SetVolume;
        _musicSlider.SliderChanged += Music.Instance.SetVolume;

        _audioSlider.Initialize(PlayerPrefs.GetFloat("Volume_clicker", 1f));
        _musicSlider.Initialize(PlayerPrefs.GetFloat("Volume_music", 1f));
    }
}

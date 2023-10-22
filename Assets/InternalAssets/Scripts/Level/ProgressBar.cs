using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;

    public void UpdateProgress(float wakeLevel)
    {
        _progressBar.fillAmount = wakeLevel;
    }
}

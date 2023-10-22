using TMPro;
using UIModule;
using UnityEngine;

public static class ProgressSaver
{
    public static bool LevelHasCompleted(int level)
    {
        return PlayerPrefs.GetInt($"level_{level}", 0) == 1;
    }

    public static void CompleteLevel(int level)
    {
        PlayerPrefs.SetInt($"level_{level}", 1);
    }
}

public class LevelSelectView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _level;

    public void Initialize(int level)
    {
        GetComponent<CustomButton>().interactable = (level == 1) || ProgressSaver.LevelHasCompleted(level - 1);
        _level.text = level.ToString();
    }
}

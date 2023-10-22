using Eflatun.SceneReference;
using UIModule;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public const int Levels = _levelSelectors * _levelsAtOneSelector;

    private const int _levelSelectors = 2;
    private const int _levelsAtOneSelector = 15;

    [SerializeField] private LevelSelectView[] _levelSelectorViews;

    public void Initialize(SceneLoader loader, LevelData levelData, int order)
    {
        for (int i = 0; i < _levelsAtOneSelector; i++)
        {
            int a = i;
            _levelSelectorViews[a].Initialize(_levelsAtOneSelector * order + a + 1);

            var button = _levelSelectorViews[a].GetComponent<CustomButton>();
            button.Initialize();
            button.onClick?.AddListener(() =>
            {
                Debug.Log("click " + a);
                levelData.SelectLevel(_levelsAtOneSelector * order + a + 1);
                loader.LoadLevel(levelData.CurrentLevelScene);
            });
        }
    }
}

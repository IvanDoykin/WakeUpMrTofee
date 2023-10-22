using UIModule;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SceneLoader _loader;
    private LevelData _levelData;
    private Panel[] _panels;
    private LevelSelector[] _levelSelectors;

    private void Awake()
    {
        _loader = FindObjectOfType<SceneLoader>();
        _levelData = FindObjectOfType<LevelData>();
        _panels = GetComponentsInChildren<Panel>(true);
        _levelSelectors = GetComponentsInChildren<LevelSelector>(true);

        foreach (var panel in _panels)
        {
            panel.Initialize();
        }

        for (int i = 0; i < _levelSelectors.Length; i++)
        {
            _levelSelectors[i].Initialize(_loader, _levelData, i);
        }
    }
}

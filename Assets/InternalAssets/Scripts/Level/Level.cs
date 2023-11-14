using System.Runtime.InteropServices;
using UIModule;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SleepTofu _tofu;

    private ProgressBar _progressBar;
    private CompletePanelView _completePanel;
    private LevelData _levelData;
    private SceneLoader _loader;
    private Panel[] _panels;
    private Music _music;

    private bool _completed = false;

    [DllImport("__Internal")]
    private static extern void ShowAdvertisment();

    private void Awake()
    {
        _progressBar = GetComponentInChildren<ProgressBar>(true);
        _completePanel = GetComponentInChildren<CompletePanelView>(true);
        _levelData = FindObjectOfType<LevelData>();
        _loader = FindObjectOfType<SceneLoader>();
        _panels = GetComponentsInChildren<Panel>(true);
        _music = FindObjectOfType<Music>();

        _completePanel.Initialize(_levelData);
        foreach (var panel in _panels)
        {
            panel.Initialize();
        }
    }

    private void Update()
    {
        _progressBar.UpdateProgress(_tofu.WakeLevel);
        if (!_completed && _tofu.WakeLevel == 1f)
        {
            Complete();
        }
    }

    public void Reload()
    {
        ShowAdvertisment();
        _loader.ReloadLevel();
        _music.PlayDefaultMusic();
    }

    public void LoadMenu()
    {
        _loader.LoadMenu();
        _music.PlayDefaultMusic();
    }

    public void LoadNextLevel()
    {
        ShowAdvertisment();
        _loader.LoadLevel(_levelData.NextLevel);
        _levelData.SelectLevel(_levelData.CurrentLevel + 1);
        _music.PlayDefaultMusic();
    }

    private void Complete()
    {
        _completed = true;
        ProgressSaver.CompleteLevel(_levelData.CurrentLevel);
        _completePanel.GetComponent<Panel>().Open();
        _music.PlayWinMusic();
    }
}
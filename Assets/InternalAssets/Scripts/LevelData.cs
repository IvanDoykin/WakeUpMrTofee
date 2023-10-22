using Eflatun.SceneReference;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private SceneReference[] _levels;
    private int _currentLevel;

    public bool HasNextLevel => _currentLevel < _levels.Length;
    public SceneReference CurrentLevelScene => _levels[_currentLevel - 1];
    public int CurrentLevel => _currentLevel;
    public SceneReference NextLevel
    {
        get
        {
            if (HasNextLevel)
            {
                return _levels[_currentLevel];
            }
            return null;
        }
    }

    public void SelectLevel(int level)
    {
        _currentLevel = level;
    }
}

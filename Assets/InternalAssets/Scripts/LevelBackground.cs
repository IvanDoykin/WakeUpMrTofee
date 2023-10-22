using UnityEngine;

public class LevelBackground : MonoBehaviour
{
    [SerializeField] private GameObject _clickIgnoreFiller;

    public void MakeLighter()
    {
        _clickIgnoreFiller.SetActive(false);
    }

    public void MakeDarker()
    {
        _clickIgnoreFiller.SetActive(true);
    }
}

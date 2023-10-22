using TMPro;
using UIModule;
using UnityEngine;

public class CompletePanelView : MonoBehaviour
{
    [SerializeField] private CustomButton _button;
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize(LevelData data)
    {
        _button.gameObject.SetActive(data.HasNextLevel);
        _text.text = $"Completed level {data.CurrentLevel}";
    }
}

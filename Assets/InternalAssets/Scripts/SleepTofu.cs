using System.Collections;
using UnityEngine;

public class SleepTofu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private Sprite _wakedSprite;
    [SerializeField] private GameObject _sleepingSign;

    private const float _wakeForUnitVertical = 1f;
    private const float _wakeForUnitHorizontal = 0.1f;

    private const float _timeToCanWake = 1f;

    private float _wakeLevel = 0f;
    public float WakeLevel => _wakeLevel;

    private Vector3 _startPosition;
    private bool _canWaked = false;
    private bool _waked = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_timeToCanWake);
        _canWaked = true;
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_canWaked)
        {
            _wakeLevel = Mathf.Max(Mathf.Clamp(Mathf.Abs(transform.position.x - _startPosition.x) * _wakeForUnitHorizontal +
                Mathf.Abs(transform.position.y - _startPosition.y) * _wakeForUnitVertical, 0f, 1f), _wakeLevel);
        }
        if (!_waked && _wakeLevel == 1f)
        {
            _waked = true;
            _render.sprite = _wakedSprite;
            _sleepingSign.SetActive(false);
        }
    }
}

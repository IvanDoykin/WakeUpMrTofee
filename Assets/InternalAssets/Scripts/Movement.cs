using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float _timeForMovement = 1f;

    [SerializeField] private Transform _pointStart;
    [SerializeField] private Transform _pointEnd;

    private Rigidbody2D _body;
    private bool _reversed;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_reversed)
        {
            _body.MovePosition(transform.position + (_pointEnd.transform.position - _pointStart.transform.position) * _timeForMovement * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, _pointEnd.transform.position) < 0.1f)
            {
                _reversed = false;
            }
        }
        else
        {
            _body.MovePosition(transform.position + (_pointStart.transform.position - _pointEnd.transform.position) * _timeForMovement * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, _pointStart.transform.position) < 0.1f)
            {
                _reversed = true;
            }
        }
    }
}

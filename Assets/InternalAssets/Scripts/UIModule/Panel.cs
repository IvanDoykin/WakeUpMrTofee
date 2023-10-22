using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UIModule
{
    public sealed class Panel : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onOpen;
        [SerializeField] private UnityEvent _onClose;

        [SerializeField] private CustomButton[] _buttons;
        [SerializeField] private UnityEvent[] _onButtonsClick;

        public void Initialize()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                int a = i;
                _buttons[a].Initialize();
                _buttons[a].onClick?.AddListener(() =>
                {
                    Debug.Log("click " + a);
                    _onButtonsClick[a]?.Invoke();
                });
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _onOpen?.Invoke();
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _onClose?.Invoke();
        }
    }
}
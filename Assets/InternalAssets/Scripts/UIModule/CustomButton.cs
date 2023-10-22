using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public sealed class CustomButton : Button
    {
        public static Action HasClicked;

        public void Initialize()
        {
            onClick.AddListener(() => HasClicked?.Invoke());
        }
    }
}
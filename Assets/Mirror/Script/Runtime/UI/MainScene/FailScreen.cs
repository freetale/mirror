using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Runtime.UI.MainScene
{
    public class FailScreen : MonoBehaviour
    {
        [Required] public Button RetryButton;


        public event Action OnRetryClick;

        public void Initialize()
        {
            RetryButton.onClick.AddListener(RetryButton_OnClick);
        }

        private void RetryButton_OnClick()
        {
            OnRetryClick.Invoke();
        }
    }
}

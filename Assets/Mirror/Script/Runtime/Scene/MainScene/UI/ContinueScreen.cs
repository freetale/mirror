using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Runtime.Scene.MainScene
{
    [Obsolete]
    public class ContinueScreen : UIScreenBase
    {

        [Required] public Button ContinueButton;

        public event Action OnContinueClick;

        public void Initialize()
        {
            ContinueButton.onClick.AddListener(ContinueButton_OnClick);
        }

        private void ContinueButton_OnClick()
        {
            OnContinueClick.Invoke();
        }
    }
}

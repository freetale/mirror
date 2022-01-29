using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Runtime.Scene.MainScene
{
    public class EntryScreen : UIScreenBase
    {
        [Required] public Button StartButton;


        public event Action OnStart;

        public void Initialize()
        {
            StartButton.onClick.AddListener(StartButton_OnClick);
        }

        private void StartButton_OnClick()
        {
            OnStart.Invoke();
        }
    }
}

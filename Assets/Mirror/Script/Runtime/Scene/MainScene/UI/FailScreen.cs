using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Runtime.Scene.MainScene
{
    public class FailScreen : UIScreenBase
    {
        [Required] public Button RetryButton;
        [Required] public TMP_Text MileTraveledText;
        [Required] public TMP_Text LongestRunText;
        [Required] public TMP_Text MilePastedText;

        public event Action OnRetryClick;

        [NonSerialized] public string MileTraveledFormat = "{0} Mile <size=36>Traveled</size>";
        [NonSerialized] public string LongestRunFormat = "<size=36>longest run</size> {0} Mile";
        [NonSerialized] public string MilePastedFormat = "{0} Mile Pasted";

        private int mileTraveled;
        public int MileTraveled
        {
            get => mileTraveled;
            set
            {
                mileTraveled = value;
                MileTraveledText.SetText(string.Format(MileTraveledFormat, mileTraveled));
            }
        }
        private int longestRun;
        public int LongestRun
        {
            get => longestRun;
            set
            {
                longestRun = value;
                LongestRunText.SetText(string.Format(LongestRunFormat, mileTraveled));
            }
        }

        private int milePasted;
        public int MilePasted
        {
            get => milePasted;
            set
            {
                milePasted = value;
                MilePastedText.SetText(string.Format(MilePastedFormat, milePasted));
            }
        }

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

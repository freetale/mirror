using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mirror.Runtime
{
    public class MileCounter : MonoBehaviour
    {
        [Required] public TMP_Text MileText;
        private int mile;

        public int Mile
        {
            get => mile;
            set
            {
                mile = value;
                MileText.SetText(mile.ToString());
            }
        }

        public void Initialize()
        {
            
        }
    }
}

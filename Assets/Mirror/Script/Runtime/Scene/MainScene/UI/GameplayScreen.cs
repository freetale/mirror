using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class GameplayScreen : UIScreenBase
    {
        [Required] public HealthIconGroup HealthIconGroup;
        [Required] public MileCounter MileCounter;

        public void Initialize()
        {
            HealthIconGroup.Initialize();
            MileCounter.Initialize();
        }
    }
}

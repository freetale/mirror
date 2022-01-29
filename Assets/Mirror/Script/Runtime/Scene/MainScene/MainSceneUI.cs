using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class MainSceneUI : MonoBehaviour
    {
        [Required] public EntryScreen EntryScreen;
        [Required] public GameplayScreen GameplayScreen;
        [Required] public FailScreen FailScreen;
        [Required] public ContinueScreen ContinueScreen;

        public void Initialize()
        {
            EntryScreen.Initialize();
            GameplayScreen.Initialize();
            FailScreen.Initialize();
            ContinueScreen.Initialize();
        }
    }
}

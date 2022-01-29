using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class FailState : IState
    {
        public FailState(MainScene mainScene)
        {
            MainScene = mainScene;
        }

        public MainScene MainScene { get; set; }

        public IState EntryState { get; set; }

        public void OnEnterState()
        {
            var failScreen = MainScene.MainSceneUI.FailScreen;
            failScreen.IsActive = true;
            failScreen.OnRetryClick += FailScreen_OnRetryClick;
        }

        private void FailScreen_OnRetryClick()
        {
            MainScene.NextState(EntryState);
        }

        public void Update(float deltaTime)
        {

        }

        public void OnExitState()
        {
            var failScreen = MainScene.MainSceneUI.FailScreen;
            failScreen.IsActive = false;
        }
    }
}

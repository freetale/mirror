using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class ContinueState : IState
    {
        public ContinueState(MainScene mainScene)
        {
            MainScene = mainScene;
        }


        public MainScene MainScene { get; set; }

        public IState GameplayState { get; set; }

        private ContinueScreen continueScreen => MainScene.MainSceneUI.ContinueScreen;

        public void OnEnterState()
        {
            continueScreen.IsActive = true;
            continueScreen.OnContinueClick += ContinueScreen_OnContinueClick;
        }

        public void Update(float deltaTime)
        {

        }

        private void ContinueScreen_OnContinueClick()
        {
            MainScene.NextState(GameplayState);
        }

        public void OnExitState()
        {
            continueScreen.IsActive = false;
            continueScreen.OnContinueClick -= ContinueScreen_OnContinueClick;
        }
    }
}

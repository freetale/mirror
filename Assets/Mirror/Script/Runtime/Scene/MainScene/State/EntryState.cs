using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class EntryState : IState
    {
        public EntryState(MainScene mainScene)
        {
            MainScene = mainScene;
        }

        public MainScene MainScene { get; set; }

        public IState GameplayState { get; set; }

        public void OnEnterState()
        {
            var entryScreen = MainScene.MainSceneUI.EntryScreen;
            entryScreen.IsActive = true;
            entryScreen.OnStart += EntryScreen_OnStart;
        }

        private void EntryScreen_OnStart()
        {
            MainScene.NextState(GameplayState);
        }

        public void Update(float deltaTime)
        {

        }

        public void OnExitState()
        {
            var entryScreen = MainScene.MainSceneUI.EntryScreen;
            entryScreen.IsActive = false;

        }
    }
}

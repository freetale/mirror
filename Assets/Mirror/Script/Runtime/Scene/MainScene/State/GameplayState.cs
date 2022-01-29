using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class GameplayState : IState
    {
        public GameplayState(MainScene mainScene)
        {
            MainScene = mainScene;
        }

        public MainScene MainScene { get; set; }

        public IState FailState { get; set; }
        public IState ContinueState { get; set; }

        public void OnEnterState()
        {

        }

        public void Update(float deltaTime)
        {

        }

        public void OnExitState()
        {

        }
    }
}

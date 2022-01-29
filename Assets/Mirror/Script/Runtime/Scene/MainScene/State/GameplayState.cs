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

        public int InitialHealth { get; set; } = 3;
        public int CurrentHealth { get; set; }

        public void OnEnterState()
        {
            MainScene.MeleePlayer.OnDamage += Player_OnDamage;
            MainScene.RangePlayer.OnDamage += Player_OnDamage;

            CurrentHealth = InitialHealth;
        }

        public void Update(float deltaTime)
        {

        }

        public void FixedUpdate(float fixedDeltaTime)
        {

        }

        public void OnExitState()
        {

        }

        private void Player_OnDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                OnFail();
            }
        }

        private void OnFail()
        {
            MainScene.NextState(FailState);
        }
    }
}

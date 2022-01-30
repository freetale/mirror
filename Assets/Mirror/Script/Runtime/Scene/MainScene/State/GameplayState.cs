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
        //public IState ContinueState { get; set; }

        public int InitialHealth { get; set; } = 3;
        public int CurrentHealth { get; set; }

        public GameplayScreen GameplayScreen=> MainScene.MainSceneUI.GameplayScreen;
        public HealthIconGroup HealthIconGroup => MainScene.MainSceneUI.GameplayScreen.HealthIconGroup;
        public MileCounter MileCounter => MainScene.MainSceneUI.GameplayScreen.MileCounter;

        public float Mile { get; set; }

        public void OnEnterState()
        {
            MainScene.MeleePlayer.PlayerBase.OnDamage += Player_OnDamage;
            MainScene.RangePlayer.PlayerBase.OnDamage += Player_OnDamage;

            CurrentHealth = InitialHealth;
            HealthIconGroup.CurrentHealth = CurrentHealth;
            HealthIconGroup.MaxHealth = CurrentHealth;

            MainScene.StartSpawn();
            Mile = 0;
            GameplayScreen.IsActive = true;
        }

        public void Update(float deltaTime)
        {
            Mile += MainScene.LevelSpeed * deltaTime;
            MileCounter.Mile = (int)Mile;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
        }

        public void OnExitState()
        {
            bool isHighScore = StatManager.AppendMile((int)Mile);

            MainScene.MeleePlayer.PlayerBase.OnDamage -= Player_OnDamage;
            MainScene.RangePlayer.PlayerBase.OnDamage -= Player_OnDamage;
            MainScene.StopSpawn();
            GameplayScreen.IsActive = false;
        }

        private void Player_OnDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                OnFail();
            }
            HealthIconGroup.CurrentHealth = CurrentHealth;
        }

        private void OnFail()
        {
            MainScene.NextState(FailState);
        }
    }
}

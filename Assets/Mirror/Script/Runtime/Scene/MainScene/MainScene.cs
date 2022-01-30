using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mirror.Runtime.Scene.MainScene
{
    public class MainScene : MonoBehaviour
    {
        [Required] public InputController InputController;
        [Required] public MeleePlayer MeleePlayer;
        [Required] public RangePlayer RangePlayer;
        [Required] public MainSceneUI MainSceneUI;
        [Required] public SFXPool SFXPool;
        [Required] public ObstracleSpawner ObsSpawner;

        [Header("Config")]
        [SerializeField]
        protected float _LevelSpeed;
        public float LevelSpeed
        {
            get => _LevelSpeed;
            set
            {
                _LevelSpeed = value;
                UpdateLevelSpeed();

            }
        }

        [Header("Stage")]
        public List<GameObject> environment;

        private InputState InputState { get; set; }

        public EntryState EntryState { get; set; }
        //public ContinueState ContinueState { get; set; }
        public FailState FailState { get; set; }
        public GameplayState GameplayState { get; set; }

        private bool stateGaurd { get; set; }
        public IState CurrentState { get; set; }

        public event Action<float> OnSetLevelSpeed;

        public void Start()
        {
            MainSceneUI.Initialize();
            InitializeState();

            var state = new InputState();
            InputState = state;
            InputController.InputState = state;
            MeleePlayer.PlayerBase.InputState = state;
            RangePlayer.PlayerBase.InputState = state;

            SubscribeEnvironmentToEvent();
        }

        private void SubscribeEnvironmentToEvent()
        {
            foreach ( GameObject obj in environment )
            {
                SkyScroller scroller = obj.GetComponent<SkyScroller>();
                OnSetLevelSpeed += scroller.SetScrollSpeed;
            }
        }

        private void InitializeState()
        {
            EntryState = new EntryState(this);
            //ContinueState = new ContinueState(this);
            FailState = new FailState(this);
            GameplayState = new GameplayState(this);

            EntryState.GameplayState = GameplayState;
            //ContinueState.GameplayState = GameplayState;
            FailState.EntryState = EntryState;
            GameplayState.FailState = FailState;
            //GameplayState.ContinueState = ContinueState;

            CurrentState = EntryState;
            CurrentState.OnEnterState();
        }

        private void Update()
        {
            InputController.UpdateObject(Time.deltaTime);
            if (InputState.IsSwapDown)
            {
                SwapPlayer();
            }
            CurrentState.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            MeleePlayer.PlayerBase.FixedUpdateObject(Time.fixedDeltaTime);
            RangePlayer.PlayerBase.FixedUpdateObject(Time.fixedDeltaTime);
        }

        private void SwapPlayer()
        {
            var meleeFlip = MeleePlayer.PlayerBase.IsFlip;
            var meleePosition = MeleePlayer.PlayerBase.Position;
            var rangePosition = RangePlayer.PlayerBase.Position;
            MeleePlayer.PlayerBase.Position = rangePosition;
            RangePlayer.PlayerBase.Position = meleePosition;
            MeleePlayer.PlayerBase.IsFlip = !meleeFlip;
            RangePlayer.PlayerBase.IsFlip = meleeFlip;
            MeleePlayer.PlayerBase.Velocity *= -1;
            RangePlayer.PlayerBase.Velocity *= -1;
        }

        public void StartSpawn()
        {
            ObsSpawner.DoStartSpawn();
        }

        public void StopSpawn()
        {
            ObsSpawner.DoStopSpawn();
        }

        public void NextState(IState state)
        {
            if (stateGaurd)
            {
                Debug.LogError("State change on state ExitState or EnterState");
            }
            stateGaurd = true;
            CurrentState.OnExitState();
            CurrentState = state;
            CurrentState.OnEnterState();
            stateGaurd = false;
        }

        public void UpdateLevelSpeed()
        {
            OnSetLevelSpeed?.Invoke( _LevelSpeed );
        }

#if UNITY_EDITOR

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        void OnValidate()
        {
            // OnSetLevelSpeed?.Invoke( _LevelSpeed );
            foreach ( GameObject obj in environment )
            {
                SkyScroller scroller = obj.GetComponent<SkyScroller>();
                scroller.SetScrollSpeed( _LevelSpeed ) ;
            }
        }
#endif

    }
}

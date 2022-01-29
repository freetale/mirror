using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public class MainScene : MonoBehaviour
    {
        [Required] public InputController InputController;
        [Required] public MeleePlayer MeleePlayer;
        [Required] public RangePlayer RangePlayer;
        [Required] public MainSceneUI MainSceneUI;
        [Required] public SFXPool SFXPool;

        private InputState InputState { get; set; }

        public EntryState EntryState { get; set; }
        public ContinueState ContinueState { get; set; }
        public FailState FailState { get; set; }
        public GameplayState GameplayState { get; set; }

        private bool stateGaurd { get; set; }
        public IState CurrentState { get; set; }

        public void Start()
        {
            MainSceneUI.Initialize();
            InitializeState();

            var state = new InputState();
            InputState = state;
            InputController.InputState = state;
            MeleePlayer.PlayerBase.InputState = state;
            RangePlayer.PlayerBase.InputState = state;
        }

        private void InitializeState()
        {
            EntryState = new EntryState(this);
            ContinueState = new ContinueState(this);
            FailState = new FailState(this);
            GameplayState = new GameplayState(this);

            EntryState.GameplayState = GameplayState;
            ContinueState.GameplayState = GameplayState;
            FailState.EntryState = EntryState;
            GameplayState.FailState = FailState;
            GameplayState.ContinueState = ContinueState;

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
    }
}

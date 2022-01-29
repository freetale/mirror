using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class MainScene : MonoBehaviour
    {
        [Required] public InputController InputController;
        [Required] public PlayerBase MeleePlayer;
        [Required] public PlayerBase RangePlayer;

        private InputState InputState { get; set; }

        public void Start()
        {
            var state = new InputState();
            InputState = state;
            InputController.InputState = state;
            MeleePlayer.InputState = state;
            RangePlayer.InputState = state;
        }

        private void Update()
        {
            InputController.UpdateObject(Time.deltaTime);
            if (InputState.IsSwapDown)
            {
                SwapPlayer();
            }
        }

        private void FixedUpdate()
        {
            MeleePlayer.FixedUpdateObject(Time.fixedDeltaTime);
            RangePlayer.FixedUpdateObject(Time.fixedDeltaTime);
        }

        private void SwapPlayer()
        {
            var meleeFlip = MeleePlayer.IsFlip;
            var meleePosition = MeleePlayer.Position;
            var rangePosition = RangePlayer.Position;
            MeleePlayer.Position = rangePosition;
            RangePlayer.Position = meleePosition;
            MeleePlayer.IsFlip = !meleeFlip;
            RangePlayer.IsFlip = meleeFlip;
            MeleePlayer.Velocity *= -1;
            RangePlayer.Velocity *= -1;
        }
    }
}

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

        public void Start()
        {
            var state = new InputState();
            InputController.InputState = state;
            MeleePlayer.InputState = state;
            RangePlayer.InputState = state;
        }

        private void Update()
        {
            InputController.UpdateObject(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            MeleePlayer.FixedUpdateObject(Time.fixedDeltaTime);
            RangePlayer.FixedUpdateObject(Time.fixedDeltaTime);
        }
    }
}

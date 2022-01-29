using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class InputController : MonoBehaviour
    {
        public InputState InputState { get; set; }

        public void UpdateObject(float deltaTime)
        {
            InputState.IsJump = Input.GetButton("Jump");
            InputState.IsSlide = Input.GetButton("Slide");
        }
    }
}

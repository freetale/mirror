using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class InputController : MonoBehaviour
    {
        public event Action OnJump;
        public event Action OnSlide;

        
        private void Update()
        {
            Update(Time.deltaTime);
        }

        public void Update(float deltaTime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                OnJump?.Invoke();
            }
            if (Input.GetButtonDown("Slide"))
            {
                OnSlide?.Invoke();
            }
        }
    }
}

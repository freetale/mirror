using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class InputState
    {
        public bool IsJump { get; set; }
        public bool IsSlide { get; set; }
        public bool IsFireDown { get; set; }

        public bool IsSwapDown { get; set; }
    }
}

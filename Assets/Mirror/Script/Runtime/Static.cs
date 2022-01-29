using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class Static
    {

        public static LayerMask PlayerLayer { get; } =  1 << LayerMask.NameToLayer("Player");
        public static LayerMask GroundLayer { get; } = 1 << LayerMask.NameToLayer("Ground");
    }
}

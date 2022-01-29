using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class Static
    {

        public static LayerMask PlayerLayer { get; } = LayerMask.NameToLayer("Player");
        public static LayerMask GroundLayer { get; } = LayerMask.NameToLayer("Ground");
        public static LayerMask DamageObstrucleLayer { get; } = LayerMask.NameToLayer("DamageObstrucle");
    }
}

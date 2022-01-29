using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class RangePlayer : MonoBehaviour
    {
        [Required] public PlayerBase PlayerBase;
        [Required] public Transform AttackStartLocator;

        public void DoAttack()
        {
            var position = AttackStartLocator.position;
            // TODO: spawn bullet
        }


#if UNITY_EDITOR

        public void Reset()
        {
            PlayerBase = GetComponent<PlayerBase>();
        }

#endif
    }
}

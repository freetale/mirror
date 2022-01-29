using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class RangePlayer : MonoBehaviour
    {
        [Required] public PlayerBase PlayerBase;

        public void DoAttack()
        {
            
        }


#if UNITY_EDITOR

        public void Reset()
        {
            PlayerBase = GetComponent<PlayerBase>();
        }

#endif
    }
}

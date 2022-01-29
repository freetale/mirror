using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class AbstractFlipable : MonoBehaviour
    {
        [Header("Flip")]
        [SerializeField]
        protected bool _isFlip;
        public virtual bool IsFlip
        {
            get;
            set;
        }
    }
}

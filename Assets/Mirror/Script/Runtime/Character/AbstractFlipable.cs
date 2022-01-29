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
            get => _isFlip;
            set
            {
                _isFlip = value;
                UpdateFlip();
            }
        }

        protected virtual void UpdateFlip(){
            throw new System.NotImplementedException("Update flip for " +  this.GetType().Name + " class is not implemented yet " );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mirror.Runtime
{
    public class Obstacle : AbstractFlipable
    {
        public int Damage = 1;

        // ########################################
        // CLASS FUNCTION
        // ########################################

        protected override void UpdateFlip()
        {
            transform.localScale = new Vector3(1, _isFlip ? -1 : 1, 1);
        }

#if UNITY_EDITOR
        /// <summary>
        /// Reset is called when the user hits the Reset button in the Inspector's
        /// context menu or when adding the component the first time.
        /// </summary>
        void Reset()
        {
        }

        private void OnValidate()
        {
            UpdateFlip();
            EditorUtility.SetDirty(transform);
        }
#endif

    }
}

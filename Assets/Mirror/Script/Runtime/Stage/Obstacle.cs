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

        // ########################################
        //  CLASS MEMBER
        // ########################################

        [Header("Config")]
        private float ScrollSpeed;
        public float ScrollSpeedMultiplier = 1;
        public float LeftBound;
        public int Damage = 1;

        // ########################################
        // CLASS FUNCTION
        // ########################################

        protected override void UpdateFlip()
        {
            transform.localScale = new Vector3(1, _isFlip ? -1 : 1, 1);
        }

        protected void UpdateObject( float deltaTime )
        {
            
            Scroll( deltaTime );

            // reset position if out of screen
            if ( transform.position.x < LeftBound )
            {
                gameObject.SetActive( false );
            }

        }

        void Scroll( float deltaTime )
        {
            // move object
            transform.Translate( - ScrollSpeed * ScrollSpeedMultiplier * deltaTime, 0, 0) ;
        }

        // event set scrollspeed subscriber
        public void SetScrollSpeed( float speed )
        {

            ScrollSpeed = speed;

        }

        // ########################################
        // CLASS BUILDIN FUNCTION
        // ########################################

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

            UpdateObject( Time.deltaTime );
        
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

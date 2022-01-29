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

        [Header("Component")]
        public SkyScroller GroundScroll;

        [Header("Config")]
        public float ScrollSpeed;
        public float LeftBound;
        public int Damage = 1;

        // ########################################
        // CLASS FUNCTION
        // ########################################

        protected override void UpdateFlip()
        {
            transform.localScale = new Vector3(1, _isFlip ? -1 : 1, 1);
        }

        void UpdateObject( float deltaTime )
        {
            
             // move object
            transform.Translate( - ScrollSpeed * deltaTime, 0, 0) ;

            // reset position if out of screen
            if ( transform.position.x < LeftBound )
            {
                gameObject.SetActive( false );
            }

        }

        // ########################################
        // CLASS BUILDIN FUNCTION
        // ########################################

        // Start is called before the first frame update
        void Start()
        {

            // TODO: spawner should assign speed 
            // ScrollSpeed = GroundScroll.ScrollSpeed;
        
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
            GroundScroll = GetComponent<SkyScroller>();
        }

        private void OnValidate()
        {
            UpdateFlip();
            EditorUtility.SetDirty(transform);
        }
#endif

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class Obstrucle : MonoBehaviour
    {
        [Header("Component")]
        public SkyScroller GroundScroll;

        [Header("Config")]
        private float ScrollSpeed;
        public float LeftBound;

        // Start is called before the first frame update
        void Start()
        {

            ScrollSpeed = GroundScroll.ScrollSpeed;
        
        }

        // Update is called once per frame
        void Update()
        {

            UpdateObject( Time.deltaTime );
        
        }

        void UpdateObject( float deltaTime )
        {
            
             // move object
            transform.Translate( - ScrollSpeed * deltaTime, 0, 0) ;

            // reset position if out of screen
            if ( transform.position.x < LeftBound )
            {
                Destroy( gameObject );
            }

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
#endif

    }
}

using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class SkyScroller : MonoBehaviour
    {

        // ########################################
        //  CLASS MEMBER
        // ########################################

        [Header("Component")]
        [Required]
        public BoxCollider2D Collider;

        [Header("Config")]
        public float ScrollSpeed;
        public bool isEableCollider;

        private float width;

        // ########################################
        // CLASS FUNCTION
        // ########################################
        
        public void UpdateObject( float deltaTime)
        {   
            // move object
            slide( - ScrollSpeed * deltaTime ) ;

            // reset position if out of screen
            if ( transform.position.x < -width )
            {
                resetPosition( width * 2f, 0 );
            }
        }

        private void slide( float distance )
        {
            transform.Translate( distance, 0, 0) ;
        }

        private void resetPosition( float positionX, float positionY )
        {
            Vector3 resetPostion = new Vector3( positionX, positionY, 0 );
            transform.position = transform.position + resetPostion;
        }

        // ########################################
        // CLASS BUILDIN FUNCTION
        // ########################################

        // Start is called before the first frame update
        void Start()
        {
            width = Collider.size.x;
            Collider.enabled = isEableCollider;

        }

        // Update is called once per frame
        void Update()
        {
            UpdateObject( Time.deltaTime );
        }

#if UNITY_EDITOR
        // Get component when reset in inspector
        void Reset()
        {
            Collider = GetComponent<BoxCollider2D>();
        }
#endif

        
       
    }
}

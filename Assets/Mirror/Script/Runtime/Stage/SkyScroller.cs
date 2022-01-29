using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class SkyScroller : MonoBehaviour
    {
        // ############## PUBLIC MEMBER ######################
        public BoxCollider2D collider;
        public float scrollSpeed;
        public bool isEableCollider;

        // ############## PRIVATE MEMBER######################

        private float width;

        // ############## 

        // Start is called before the first frame update
        void Start()
        {
            width = collider.size.x;
            collider.enabled = isEableCollider;

        }

        // Update is called once per frame
        void Update()
        {
            UpdateObject( Time.deltaTime );
        }

        public void UpdateObject( float deltaTime)
        {   
            // move object
            transform.Translate( - scrollSpeed * deltaTime, 0, 0) ;

            // reset position if out of screen
            if ( transform.position.x < -width )
            {
                Vector3 resetPostion = new Vector3( width * 2f, 0, 0 );
                transform.position = transform.position + resetPostion;
            }

        }

        // Get component when reset in inspector
        void Reset()
        {
            collider = GetComponent<BoxCollider2D>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class DestructableObstacle : Obstacle
    {
    
        // ########################################
        //  CLASS MEMBER
        // ########################################

        [Header("Destructable Config")]
        public int MaxHealth = 1;
        private int CurrentHealth = 1;

        public bool isSwordVulnerable;
        public bool isGunVulnerable;
        

        // ########################################
        // CLASS FUNCTION
        // ########################################

        void UpdateObject( float deltaTime )
        {
        
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
        
        }

        public void OnSwordDamage( int damage )
        {
            if ( isSwordVulnerable )
            {
                OnDamage( damage );
            }
        }

        public void OnGunDamage( int damage )
        {
            if ( isGunVulnerable )
            {
                OnDamage( damage );
            }

        }

        private void OnDamage( int damage )
        {
            CurrentHealth -= damage;

            if ( CurrentHealth <= 0 )
            {
                OnDestroy();
            }

        }

        private void OnDestroy()
        {
            gameObject.SetActive( false );
        }

        // ########################################
        // CLASS EDITOR FUNCTION
        // ########################################

        #if UNITY_EDITOR


        #endif

    
    }
}
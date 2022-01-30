using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class ObstracleSpawner : MonoBehaviour
    {

        // ########################################
        //  CLASS MEMBER
        // ########################################

        public ObstaclePools pools;

        private bool isStartSpawn;

        public Scene.MainScene.MainScene Scene;

        // ########################################
        // CLASS FUNCTION
        // ########################################

        // event subscriber
        public void DoStartSpawn()
        {
            SetSpawn( true );
        }

        // event subscriber
        public void DoStopSpawn()
        {
            SetSpawn( false );
        }

        private void SetSpawn( bool shouldSpawn )
        {
            isStartSpawn = shouldSpawn;
        }

        void UpdateObject( float deltaTime)
        {

            // continue spawn
            if ( isStartSpawn )
            {
                // TODO: get some spawn condition
                if ( Random.value * 100 < pools.Pools[0].spawnChance_percent )
                {
                    SpawnObstracle();
                }

            }
            
        }

        private void SpawnObstracle()
        {
            // TODO : get spawning method
            // random generate? setting file? tile? 

            // random position on 2d space
            Vector2 spawnPosition = new Vector2( Random.Range( 10, 20 ), Random.Range( -3, 3 ) );
            
            // if position < 0 meaning object is in mirror world (flip)
            bool isFlip = spawnPosition.y < 0;

            //  if object is blow non-dodgable height then move up
            if ( Mathf.Abs(spawnPosition.y) < 0.5f )
            {
                if( isFlip )
                    spawnPosition.y = -0.6f;
                else
                    spawnPosition.y = 0.6f;
            }  

            // spawn box
            GameObject spawnedObject = pools.SpawnObject( "Box", spawnPosition );

            // set correct flip
            Obstacle obstacle = spawnedObject.GetComponent< Obstacle >();
            obstacle.IsFlip = isFlip ;

            obstacle.SetScrollSpeed( Scene.LevelSpeed );
            Scene.OnSetLevelSpeed += obstacle.SetScrollSpeed;
        
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

        // ########################################
        // CLASS EDITOR FUNCTION
        // ########################################
        
        /// <summary>
        /// Reset is called when the user hits the Reset button in the Inspector's
        /// context menu or when adding the component the first time.
        /// </summary>
        void Reset()
        {
            pools = GetComponent< ObstaclePools >();
        }
        
    }
}

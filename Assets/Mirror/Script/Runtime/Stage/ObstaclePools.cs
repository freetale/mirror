using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class ObstaclePools : MonoBehaviour
    {
        // ########################################
        //  CLASS MEMBER
        // ########################################

        // a pool
        [System.Serializable]
        public class GameObjectPool
        {
            public string poolName;
            public int poolSize;
            public GameObject prefab;
            public float spawnChance_percent;

        }

        // list of pools
        public List< GameObjectPool > Pools;

        // pool name to pool queue dict
        public Dictionary< string, Queue< GameObject > > PoolDict;

        // ########################################
        // CLASS FUNCTION
        // ########################################

        private void InstantiateAllObjectInPool()
        {
            // instantiate all object in every pool
            foreach ( GameObjectPool pool in Pools )
            {
                // init queue
                Queue< GameObject > objectPool = new Queue< GameObject >();
                for ( int i = 0 ; i < pool.poolSize; i++ )
                {
                    // instantiate inactive object
                    GameObject obj = Instantiate( pool.prefab );
                    obj.SetActive( false );
                    objectPool.Enqueue( obj );
                }

                // add queue to dict
                PoolDict.Add( pool.poolName, objectPool );
            }
        }

        // spawn object from queue
        public GameObject SpawnObject( string type, Vector2 position, Quaternion rotoation = default( Quaternion ) )
        {

            // if no pool of this type found
            if ( !PoolDict.ContainsKey( type ) )
            {
                Debug.LogWarning( "type " + type + " not exist" );
                return null;
            }

            GameObject spawnObject = PoolDict[ type ].Dequeue();

            // active object with position and rotation
            spawnObject.SetActive( true );
            spawnObject.transform.position = new Vector3( position.x, position.y, 0 );
            spawnObject.transform.rotation = rotoation;

            PoolDict[ type ].Enqueue( spawnObject );
            
            return spawnObject;
        }

    }
}

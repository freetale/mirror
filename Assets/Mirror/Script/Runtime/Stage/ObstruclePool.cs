using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class ObstruclePool : MonoBehaviour
    {
        // ########################################
        //  CLASS MEMBER
        // ########################################

        public List< GameObjectPool > pools;
        public Dictionary< string, Queue< GameObject > > poolDict;

        // ########################################
        // CLASS FUNCTION
        // ########################################

        [System.Serializable]
        public class GameObjectPool
        {
            public string poolName;
            public int poolSize;
            public GameObject prefab;

        }

        private void instantiateAllObjectInPool()
        {
            foreach( GameObjectPool pool in pools )
            {
                Queue< GameObject > objectPool = new Queue< GameObject >();
                for ( int i = 0 ; i < pool.poolSize; i++ )
                {
                    GameObject obj = Instantiate( pool.prefab );
                    obj.SetActive( false );
                    objectPool.Enqueue( obj );
                }
            }
        }

        public GameObject spawnObject( string type, Vector3 position, Quaternion rotoation)
        {
            if ( !poolDict.ContainsKey( type ) )
            {
                Debug.LogWarning( "type " + type + " not exist" );
                return null;
            }

            GameObject spawnObject = poolDict[ type ].Dequeue();

            spawnObject.SetActive( true );
            spawnObject.transform.position = position;
            spawnObject.transform.rotation = rotoation;
            
            return spawnObject;
        }

        // ########################################
        // CLASS BUILDIN FUNCTION
        // ########################################

    }
}

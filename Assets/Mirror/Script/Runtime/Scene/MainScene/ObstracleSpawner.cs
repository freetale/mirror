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

        public List<GameObject> BlockTemplates;

        public List<Pool> pools;

        private bool isStartSpawn;

        public Scene.MainScene.MainScene Scene;

        public float SpawnDistance = 1f;
        private float currentDistance = 0;
        // ########################################
        // CLASS FUNCTION
        // ########################################
        // event subscriber
        private void Start()
        {
            for (int i = 0; i < BlockTemplates.Count; i++)
            {
                var go = new GameObject();
                var pool = go.AddComponent<Pool>();
                pool.Template = BlockTemplates[i];
                pools.Add(pool);
            }
        }
        public void DoStartSpawn()
        {
            SetSpawn(true);
        }

        // event subscriber
        public void DoStopSpawn()
        {
            SetSpawn(false);
        }

        private void SetSpawn(bool shouldSpawn)
        {
            isStartSpawn = shouldSpawn;
        }

        void UpdateObject(float deltaTime)
        {
            // continue spawn
            if (!isStartSpawn)
            {
                return;
            }
            currentDistance -= deltaTime;
            if (currentDistance < 0)
            {
                currentDistance += SpawnDistance;
                SpawnObstracle();
            }
        }

        private void SpawnObstracle()
        {
            // TODO : get spawning method
            // random generate? setting file? tile? 

            // random position on 2d space
            Vector2 spawnPosition = new Vector2(15, 0);

            var poolIndex = Random.Range(0, pools.Count);
            var pool = pools[poolIndex];
            ObstacleBlock obstacle = pool.PickOne<ObstacleBlock>();

            obstacle.ScrollSpeed = Scene.LevelSpeed;
            obstacle.transform.position = spawnPosition;
            obstacle.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateObject(Time.deltaTime);
        }

    }
}

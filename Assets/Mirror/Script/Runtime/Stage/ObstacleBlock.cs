using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class ObstacleBlock : MonoBehaviour
    {
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public float ScrollSpeed { get; set; }
        [Header("Config")]
        public float ScrollSpeedMultiplier = 2;
        public float LeftBound = -12;

        void Scroll(float deltaTime)
        {
            // move object
            transform.Translate(-ScrollSpeed * ScrollSpeedMultiplier * deltaTime, 0, 0);
            // reset position if out of screen
            if (transform.position.x < LeftBound)
            {
                IsActive = false;
            }
        }

        void UpdateObject(float deltaTime)
        {
            Scroll(deltaTime);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateObject(Time.deltaTime);
        }

#if UNITY_EDITOR
        public void OnDrawGizmos()
        {
            Gizmos.DrawLine(new Vector2(1, -3), new Vector2(1, 3));
            Gizmos.DrawLine(new Vector2(-1, -3), new Vector2(-1, 3));
            Gizmos.DrawLine(new Vector2(-1, -3), new Vector2(-1, 3));
            Gizmos.DrawLine(new Vector2(-1, -3), new Vector2(1, -3));
        }
#endif
    }
}

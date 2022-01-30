using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{

    public class Pool : MonoBehaviour
    {
        public GameObject Template;
        public List<GameObject> PrecreateInstance = new List<GameObject>();

        private HashSet<PoolChild> activeChildren = new HashSet<PoolChild>();
        private Queue<PoolChild> inactiveChildren = new Queue<PoolChild>();

        public void Start()
        {
            for (int i = 0; i < PrecreateInstance.Count; i++)
            {
                var instance = PrecreateInstance[i];
                var child = instance.AddComponent<PoolChild>();
                child.Pool = this;
                inactiveChildren.Enqueue(child);
            }
        }

        public T PickOne<T>() where T : Component
        {
            PoolChild child;
            if (inactiveChildren.Count > 0)
            {
                child = inactiveChildren.Dequeue();
            }
            else
            {
                var instance = Instantiate(Template, transform);
                child = instance.AddComponent<PoolChild>();
                child.Pool = this;
            }
            activeChildren.Add(child);
            return child.GetComponent<T>();
        }

        internal void ReturnObject(PoolChild child)
        {
            if (activeChildren.Remove(child))
            {
                inactiveChildren.Enqueue(child);
            }
            else
            {
                Debug.LogError("return item from wrong pool");
            }
        }
    }
}

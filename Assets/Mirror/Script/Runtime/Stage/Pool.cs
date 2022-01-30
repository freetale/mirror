using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{

    public class Pool : MonoBehaviour
    {
        public GameObject Template;
        public List<GameObject> PrecreateInstance;
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

        //public T PickOne<T>() where T :Component
        //{
        //    PoolChild child;
        //    if (inactiveChildren.Count > 0)
        //    {
        //        child = inactiveChildren.Dequeue();
        //    }
        //    else
        //    {
        //        child = new PoolChild()
        //    }
        //}
    }
}

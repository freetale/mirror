using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{

    public class PoolChild : MonoBehaviour
    {
        public Pool Pool { get; set; }

        public void OnDisable()
        {
        }
    }
}

using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class PlayerShader : MonoBehaviour
    {
        public MeshRenderer MeshRenderer;

        public Material Material { get; set; }

        private float _fillParse;
        public float FillParse
        {
            get => _fillParse;
            set
            {
                _fillParse = value;
                Material.SetFloat("_FillParse", _fillParse);
            }
        }

        private void Start()
        {
            Material = MeshRenderer.material;
        }


    }
}

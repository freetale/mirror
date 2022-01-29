using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mirror.Runtime
{
    public class PlayerBase : MonoBehaviour
    {
        [Header("Component")]
        [Required]  public Rigidbody2D Rigidbody2D;
        [Required] public CapsuleCollider2D NormalCollider2D;
        [Required] public CapsuleCollider2D SlideCollider2D;

        public GameObject NormalCapsule; //mock
        public GameObject SlideCapsule; //mock

        [Header("Config")]
        public float JumpPower = 1f;
        public float GroundCheckDistance = 0.2f;
        public float GravityScale = 1;

        public event Action<int> OnDamage;

        [SerializeField]
        private bool _isFlip;
        public bool IsFlip
        {
            get => _isFlip;
            set
            {
                _isFlip = value;
                Rigidbody2D.gravityScale = _isFlip ? -GravityScale : GravityScale;
                transform.localScale = new Vector3(1, _isFlip ? -1 : 1, 1);
            }
        }

        private bool _isSlide;
        public bool IsSlide
        {
            get => _isSlide;
            private set
            {
                _isSlide = value;
                NormalCollider2D.enabled = !_isSlide;
                SlideCollider2D.enabled = _isSlide;
                NormalCapsule.SetActive(!_isSlide);
                SlideCapsule.SetActive(_isSlide);
            }
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Vector2 Velocity
        {
            get => Rigidbody2D.velocity;
            set => Rigidbody2D.velocity = value;
        }

        public InputState InputState { get; set; }

        /// <summary>
        /// internal use for <see cref="IsGrounded"/>
        /// </summary>
        private RaycastHit2D[] raycastHit2Ds = new RaycastHit2D[1];
        public void FixedUpdateObject(float fixedDeltaTime)
        {
            if (InputState.IsJump && IsGrounded())
            {
                DoJump();
            }
            if (InputState.IsSlide ^ _isSlide)
            {
                IsSlide = InputState.IsSlide;
            }
        }

        private void DoJump()
        {
            Rigidbody2D.velocity = new Vector2(0, IsFlip ? -JumpPower : JumpPower);
        }

        private bool IsGrounded()
        {
            var direction = _isFlip ? Vector2.up : Vector2.down;
            
            ContactFilter2D filter = new ContactFilter2D
            {
                layerMask = ~(1 << Static.GroundLayer),
            };
            int hitCount =  NormalCollider2D.Cast(direction, filter, raycastHit2Ds, GroundCheckDistance);
            return hitCount > 0;
        }

        private void TakeDamage( int damage )
        {
            Debug.Log("Take damage");
            OnDamage?.Invoke(damage);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var obstrucle = other.GetComponent<Obstrucle>();
            if (obstrucle)
            {
                TakeDamage(obstrucle.Damage);
            }
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (Rigidbody2D)
            {
                Rigidbody2D.gravityScale = _isFlip ? -GravityScale : GravityScale;
                transform.localScale = new Vector3(1, _isFlip ? -1 : 1, 1);
                EditorUtility.SetDirty(Rigidbody2D);
                EditorUtility.SetDirty(transform);
            }
        }

        private void Reset()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
#endif
    }
}

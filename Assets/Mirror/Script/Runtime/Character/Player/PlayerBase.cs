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
    public class PlayerBase : AbstractFlipable
    {
        [Header("Component")]
        [Required] public Rigidbody2D Rigidbody2D;
        [Required] public CapsuleCollider2D NormalCollider2D;
        [Required] public CapsuleCollider2D SlideCollider2D;
        [Required] public PlayerAnimator PlayerAnimator;
        [Required] public PlayerShader PlayerShader;

        [Header("Config")]
        public float JumpPower = 1f;
        public float GroundCheckDistance = 0.2f;
        public float GravityScale = 1;
        public bool isMelee = false;

        public event Action<int> OnDamage;

        private bool _isSlide;
        public bool IsSlide
        {
            get => _isSlide;
            private set
            {
                _isSlide = value;
                NormalCollider2D.enabled = !_isSlide;
                SlideCollider2D.enabled = _isSlide;
                PlayerAnimator.IsSlide = _isSlide;
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
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            PlayerAnimator.IsMelee = isMelee;

        }

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
            PlayerAnimator.Velocity = Rigidbody2D.velocity.y * (_isFlip ? -1 : 1);


            if ( InputState.IsFireDown )
            {
                PlayerAnimator.IsAttack = true;
            }
            else
            {
                PlayerAnimator.IsAttack = false;
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
        
        protected override void UpdateFlip()
        {
            Rigidbody2D.gravityScale = _isFlip ? -GravityScale : GravityScale;
            transform.localScale = new Vector3(1, _isFlip ? -1 : 1, 1);
        }

        private void TakeDamage( int damage )
        {
            // Debug.Log( gameObject.name +  " Take damage");
            OnDamage?.Invoke(damage);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var obstacle = other.GetComponent< Obstacle >();
            if (obstacle)
            {
                TakeDamage(obstacle.Damage);
            }
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (Rigidbody2D)
            {
                UpdateFlip();
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

using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class PlayerBase : MonoBehaviour
    {
        [Header("Component")]
        [Required]
        public Rigidbody2D Rigidbody2D;
        public Collider2D NormalCollider2D;
        public Collider2D SlideCollider2D;

        [Header("Config")]
        public float JumpPower = 1f;

        public float Speed = 1;

        [SerializeField]
        private bool _isFlip;
        public bool IsFlip
        {
            get => _isFlip;
            set
            {
                _isFlip = value;
                Rigidbody2D.gravityScale = _isFlip ? -1 : 1;
            }
        }

        private bool _isSlide;
        public bool IsSlide
        {
            get => _isSlide;
            set
            {
                _isSlide = value;
                NormalCollider2D.enabled = !_isSlide;
                SlideCollider2D.enabled = _isSlide;
            }
        }

        public InputState InputState { get; set; }

        public void FixedUpdateObject(float fixedDeltaTime)
        {
            UpdatePosition(fixedDeltaTime);
            if (InputState.IsJump)
            {
                DoJump();
            }
            if (InputState.IsSlide)
            {
                DoSlide();
            }
        }

        private void UpdatePosition(float fixedDeltaTime)
        {
            Vector3 position = transform.position;
            position.x += Speed * fixedDeltaTime;
            transform.position = position;
        }

        public void DoJump()
        {
            Rigidbody2D.velocity = new Vector2(0, IsFlip ? -JumpPower : JumpPower);
        }

        public void DoSlide()
        {
            
        }

#if UNITY_EDITOR

        private void Reset()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
#endif
    }
}

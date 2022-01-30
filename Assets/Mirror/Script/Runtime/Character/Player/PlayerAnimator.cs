using NaughtyAttributes;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class PlayerAnimator : MonoBehaviour
    {
        [Required] public Animator Animator;
        [Required] public SkeletonMecanim SkeletonMecanim;

        private bool isMelee;
        private float velocity;
        private bool isSlide;

        public bool IsMelee
        {
            get => isMelee;
            set
            {
                isMelee = value;
                Animator.SetBool("Is Melee", value);
            }
        }

        public float Velocity
        {
            get => velocity;
            set
            {
                velocity = value;
                Animator.SetFloat("Velocity", value);
            }
        }

        public bool IsSlide
        {
            get => isSlide;
            set
            {
                isSlide = value;
                Animator.SetBool("Is Slide", value);
            }
        }

        public void Attack()
        {
            Animator.SetTrigger("Attack");
        }

        public void Initialize()
        {

        }
    }
}

using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class MeleePlayer : MonoBehaviour
    {
        [Required] public PlayerBase PlayerBase;
        [Required] public BoxCollider2D AttackHitbox;

        public event Action OnAttack;
        public event Action OnAttackHit;

        /// <summary>
        /// internak use for <see cref="OverlapHitbox"/>
        /// </summary>
        private List<Collider2D> colliders = new List<Collider2D>();

        public void DoAttack()
        {
            OnAttack?.Invoke(); //play sound
            OverlapHitbox();
        }

        private void OverlapHitbox()
        {
            var filter = new ContactFilter2D
            {
                layerMask = 1 << Static.DamageObstrucleLayer,
            };
            int hit = AttackHitbox.OverlapCollider(filter, colliders);
            for (int i = 0; i < hit; i++)
            {
                // check if obtracle and deal damage
                Collider2D collidingObject = colliders[ i ];
                if ( collidingObject.tag == "Destructable" )
                {
                    GameObject obstacleObject = collidingObject.gameObject;
                    DestructableObstacle obj = obstacleObject.GetComponent< DestructableObstacle >();

                    obj.OnSwordDamage( 1 );

                }
                    

            }
            if (hit > 0)
            {
                OnAttackHit?.Invoke();//play sound
            }
        }
#if UNITY_EDITOR

        public void Reset()
        {
            PlayerBase = GetComponent<PlayerBase>();
        }

#endif
    }

}

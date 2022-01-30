using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class SFXGroup : MonoBehaviour
    {
        public AudioClip Damange;
        public AudioClip Jump;
        public AudioClip Bonus;
        public AudioClip Attack;

        public SFXPool SFXPool;

        public void PlayDamage()
        {
            SFXPool.Play(Damange);
        }

        public void PlayJump()
        {
            SFXPool.Play(Jump);
        }

        public void PlayBonus()
        {
            SFXPool.Play(Bonus);
        }

        public void PlayAttack()
        {
            SFXPool.Play(Attack);
        }
    }
}

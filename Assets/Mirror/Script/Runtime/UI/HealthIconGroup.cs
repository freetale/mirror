using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class HealthIconGroup : MonoBehaviour
    {
        public HealthIcon[] Icons;

        public int MaxIcon => Icons.Length;

        [SerializeField]
        private int _maxHealth;
        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                UpdateIcon();
            }
        }
        [SerializeField]
        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                UpdateIcon();
            }
        }

        public void Initialize()
        {
            UpdateIcon();
        }

        private void UpdateIcon()
        {
            for (int i = 0; i < MaxIcon; i++)
            {
                if (i >= _maxHealth)
                {
                    Icons[i].State = HealthIcon.IconState.Hidden;
                    continue;
                }
                if (i >= _currentHealth)
                {
                    Icons[i].State = HealthIcon.IconState.Lost;
                    continue;
                }
                Icons[i].State = HealthIcon.IconState.Full;
            }
        }

        private void OnValidate()
        {
            UpdateIcon();
        }
    }
}

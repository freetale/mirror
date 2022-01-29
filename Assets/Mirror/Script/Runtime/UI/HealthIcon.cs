using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Runtime
{
    public class HealthIcon : MonoBehaviour
    {
        public enum IconState
        {
            Hidden,
            Full,
            Lost,
        }
        public Image Image;

        public Sprite FullSprite;
        public Sprite LostSprite;

        private IconState _state;
        public IconState State
        {
            get => _state;
            set
            {
                _state = value;
                UpdateState(_state);
            }
        }
        
        private void UpdateState(IconState state)
        {
            switch (state)
            {
                case IconState.Hidden:
                    gameObject.SetActive(false);
                    break;
                case IconState.Full:
                    gameObject.SetActive(true);
                    Image.sprite = FullSprite;
                    break;
                case IconState.Lost:
                    gameObject.SetActive(true);
                    Image.sprite = LostSprite;
                    break;
            }
        }
    }
}

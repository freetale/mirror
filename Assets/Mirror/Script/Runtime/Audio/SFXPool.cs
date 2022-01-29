using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public class SFXPool : MonoBehaviour
    {
        public AudioSource[] AudioSources;

        public int CurrenctSourceIndex;

        public int Next()
        {
            CurrenctSourceIndex++;
            if (CurrenctSourceIndex >= AudioSources.Length)
            {
                CurrenctSourceIndex -= AudioSources.Length;
            }
            return CurrenctSourceIndex;
        }

        public void Play(AudioClip clip)
        {
            AudioSource sources = AudioSources[Next()];
            sources.PlayOneShot(clip);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            AudioSources = GetComponents<AudioSource>();
        }
#endif
    }
}

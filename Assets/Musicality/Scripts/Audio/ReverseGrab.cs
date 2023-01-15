using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class ReverseGrab : MonoBehaviour
    {
        private AudioSource audioSource; 
        
        public bool isPlaying = false;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void StartSound()
        {
            audioSource.Play();
        }

        public void StopSound()
        {
            audioSource.Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class ReverseGrab : MonoBehaviour
    {
        public AudioClip reverseGrabClip;

        private AudioSource audioSource; 
        
        public bool isPlaying = false;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void Start()
        {
            audioSource.clip = reverseGrabClip;
        }

        public void StopSound()
        {
            audioSource.Stop();
        }
    }
}

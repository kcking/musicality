using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class PlaySoundOnTriggerPull : MonoBehaviour
    {
        public AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySoundNote()
        {
            AudioManager.instance.impactAudio.PlayRandomImpactClip(audioSource);
        }
    }
}

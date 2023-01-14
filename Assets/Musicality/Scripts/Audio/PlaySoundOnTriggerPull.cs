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
            GetComponent<SoundObject>().trigger();
            // AudioManager.instance.impactAudio.PlayRandomImpactClip(audioSource);
        }
    }
}

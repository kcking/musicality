using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class ImpactAudio : MonoBehaviour
    {
        public List<AudioClip> hardImpactClips;
        public List<AudioClip> softImpactClips;

        public Dictionary<string, AudioClip> hardImpactsDictionary = new Dictionary<string, AudioClip>();
        public Dictionary<string, AudioClip> softImpactsDictionary = new Dictionary<string, AudioClip>();

        void Awake()
        {

        }

        void Start()
        {   
            LoadClipDictionarys();
        }

        public void PlayImpactClip(string clipName, AudioSource objectSource)
        {
            AudioClip clip;
            // Try to get the clip from the dictionary
            if (hardImpactsDictionary.TryGetValue(clipName, out clip))
            {
                objectSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("Clip not found: " + clipName);
            }
        }


        private void LoadClipDictionarys()
        {
            // Add each audio clip into the dictionary. These can then be accessed by it's corresponding musical note, rather than it's index.
            string[] notes = { "Eb2", "E2", "F2", "Gb2", "G2", "Ab2", "A2", "Bb2", "B2", "C3", "Db3", "D3", "Eb3", "E3", "F3", "Gb3", "G3", "Ab3", "A3", "Bb3" };
            for (int i = 0; i < hardImpactClips.Count; i++)
            {
                hardImpactsDictionary.Add(notes[i], hardImpactClips[i]);
                softImpactsDictionary.Add(notes[i], hardImpactClips[i]);
            }
        }
    }
}

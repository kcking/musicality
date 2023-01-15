using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class DroneManager : MonoBehaviour
    {
        public List<AudioClip> droneClips;
        public List<string> droneRoots;
        public Dictionary<string, AudioClip> droneDictionary;

        private GameManager gameManager;

        void Start()
        {
            FindObjectOfType<GameManager>();
            StoreClipsInDict();
        }
        
        ///<summary>
        /// Plays the drone clip of the given root note
        ///</summary>
        public void PlayDroneClip(string droneRoot, AudioSource audioSource)
        {
            if(droneDictionary.ContainsKey(droneRoot))
            {
                audioSource.clip = droneDictionary[droneRoot];
                audioSource.Play();
            } else 
            {
                Debug.Log("Drone root not found!");
            }
        }

        private void StoreClipsInDict()
        {
            int index = 0;
            foreach (AudioClip drone in droneClips)
            {
                droneDictionary.Add(droneRoots[index], droneClips[index]);
            }
        }

    }
}

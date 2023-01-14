using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public ImpactAudio impactAudio;
        
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        
    }
}

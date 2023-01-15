using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class TrailController : MonoBehaviour
    {
        // Start is called before the first frame update
        private TrailRenderer trail;
        private ParticleSystem particles;
        void Start()
        {
            trail = GetComponent<TrailRenderer>();
            particles = GetComponent<ParticleSystem>();
            trail.enabled = false;
            particles.Stop();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonUp("Trigger"))
            {
                StartCoroutine(TrailActivate());
                // Code to execute when the trigger button is released
            }

      
        }
        IEnumerator TrailActivate(){
            trail.enabled = true;
            particles.Play();
            yield return new WaitForSeconds(1f);
            trail.enabled = false;
            particles.Stop();



        }
    }
}

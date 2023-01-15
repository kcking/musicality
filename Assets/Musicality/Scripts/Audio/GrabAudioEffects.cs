using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Foundry
{
    public class GrabAudioEffects : MonoBehaviour
    {
        // The current note value that the object would trigger if struck
        public string currentNoteValue = null;

        public bool isGrabbed;

        // What note values will be held by the differnet positions
        public string[] positionNotes = NoteLayouts.APentatonic;

        [SerializeField]
        private static float numberOfSections = 5.0f;
        private float sectionSize;

        void Awake()
        {
            // How big is each of the sections
            sectionSize = 2.0f / numberOfSections;
        }

        void Update()
        {
            // Debug.Log("UpdateKevin");
        }

        void OnCollisionEnter(Collision collision)

        {
            Debug.Log("CollisionEnter");
            if (isGrabbed)
            {
                UpdateCurrentNote();
                AudioManager.instance.impactAudio.PlayImpactClip(currentNoteValue, GetComponent<AudioSource>());
            }
        }

        public void Grabbed()
        {

            // ev.interactableObject.transform.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            // ev.interactableObject.transform.gameObject.SetActive(false);
            // ev.interactorObject.transform.gameObject.GetComponent<Collider>().isTrigger = true;
            // ev.interactorObject.transform.gameObject.GetComponent<Rigidbody>().is = false;

            Debug.Log("Grabbed");
            isGrabbed = true;
        }

        public void Released()
        {
            // ev.interactableObject.transform.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            // ev.interactorObject.transform.gameObject.GetComponent<Collider>().isTrigger = false;
            Debug.Log("Released");
            isGrabbed = false;
        }

        // Updates the current note value depending on the postion of the grabbed object. 
        private void UpdateCurrentNote()
        {
            float yPos = gameObject.transform.position.y;
            int section = (int)(yPos / sectionSize);

            if (yPos > 2.0)
                section = positionNotes.Length;
            if (yPos < 0.0)
                section = 0;

            currentNoteValue = positionNotes[section];
        }

    }
}

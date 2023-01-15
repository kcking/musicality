using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

namespace Foundry
{
    public class GrabAudioEffects : MonoBehaviour
    {
        public SoundObject soundObject;
        // The current note value that the object would trigger if struck
        public string currentNoteValue = null;
        public Color? currentColor = null;

        public bool isGrabbed;
        public bool isReversing;

        public Collision collisionRef;
        public bool isCollided;

        // What note values will be held by the differnet positions
        public string[] positionNotes = NoteLayouts.APentatonic;
        static Color[] colors = { new Color(1.0f, 0.0f, 0.0f), new Color(1.0f, 127.0f / 255.0f, 0.0f), new Color(1.0f, 1.0f, 0.0f), new Color(0.0f, 1.0f, 0.0f), new Color(0.0f, 0.0f, 1.0f), new Color(
148.0f/255.0f, 0f, 211/255.0f) };

        double? triggerTime;
        double? lastSentTriggerTime;
        double? playedTime;

        [SerializeField]
        private static float numberOfSections = 6.0f;
        private float sectionSize;

        void Awake()
        {
            // How big is each of the sections
            sectionSize = 2.0f / numberOfSections;

            soundObject = GetComponent<SoundObject>();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting && triggerTime != lastSentTriggerTime)
            {
                lastSentTriggerTime = triggerTime;
                stream.SendNext(triggerTime);
            }
            else if (stream.IsReading)
            {
                triggerTime = (double)stream.ReceiveNext();
            }
        }

        void triggerLoop()
        {
            // GetComponent<AudioSource>().Play();
            trigger();
        }

        void Update()
        {
            // Debug.Log("UpdateKevin");
            if (isGrabbed)
            {
                UpdateCurrentNote();
                if (currentColor != null)
                {
                    GetComponent<MeshRenderer>().material.color = (Color)currentColor;
                }
            }
            if (triggerTime != null)
            {
                if (playedTime != triggerTime)
                {
                    //// COLLISSION METHOD TO TRIGGER SOUND!!!!!!!
                    // if(isCollided)
                    // {
                    //     AudioManager.instance.impactAudio.PlayImpactClip(noteValue, audioSource, collisionRef);
                    //     isCollided = false;
                    // } else 
                    {
                        //  play it!
                        playedTime = triggerTime;
                        // AudioManager.instance.impactAudio.PlayImpactClip("G2", GetComponent<AudioSource>());
                        AudioManager.instance.impactAudio.PlayImpactClip(currentNoteValue, GetComponent<AudioSource>());
                    }
                }
            }
        }

        private double triggerTime;
        private string triggerClip;

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("CollisionEnter");
            if (isGrabbed)
            {
                Debug.Log("MagnitudeOfCollision is " + collision.relativeVelocity.magnitude);
                GameObject other = collision.gameObject;
                if (string.Compare(other.GetComponent<SoundObject>().id, this.GetComponent<SoundObject>().id) < 0)
                {   
                    UpdateCurrentNote();
                    collisionRef = collision;
                    isCollided = true;
                    trigger();
                    //AudioManager.instance.impactAudio.PlayImpactClip(currentNoteValue, GetComponent<AudioSource>());
                }
            }
        }

        public void Grabbed()
        {
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
            float yPos = gameObject.transform.position.y - 0.2f; // translate down a little
            int section = (int)(yPos / sectionSize);

            if (yPos > 2.0)
                section = positionNotes.Length - 1;
            if (yPos < 0.0)
                section = 0;

            if (section < colors.Length)
            {
                currentColor = (Color)colors[section];
            }
            currentNoteValue = positionNotes[section];
        }

        public void trigger()
        {
            Debug.Log(PhotonNetwork.Time);
            triggerTime = PhotonNetwork.Time;
        }

    }
}

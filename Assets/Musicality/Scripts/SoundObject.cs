using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Foundry
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundObject : MonoBehaviour, Photon.Pun.IPunObservable
    {
        public GameManager gameManager;
        public string noteValue;

        private AudioSource audioSource;

        public bool isCollided;
        public Collision collisionRef;
            
        double? triggerTime;
        double? lastSentTriggerTime;
        double? playedTime;


        void Start()
        {
            FindObjectOfType<GameManager>();
            audioSource = GetComponent<AudioSource>();
            noteValue = gameManager.currentAvailableNotes[Random.Range(0, gameManager.currentAvailableNotes.Count)];
            // If nothing is assigned to current available notes then 
            if(gameManager.currentAvailableNotes == null)
                noteValue = GameManager.allAvailableNotes[Random.Range(0, GameManager.allAvailableNotes.Length)];
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

        // Update is called once per frame
        void Update()
        {
            //  Color change code (random color)
            // GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            if (triggerTime != null)
            {
                if (playedTime != triggerTime)
                {
                    if(isCollided)
                    {
                        AudioManager.instance.impactAudio.PlayImpactClip(noteValue, audioSource, collisionRef);
                        isCollided = false;
                    } else 
                    {
                        //  play it!
                        playedTime = triggerTime;
                        // AudioManager.instance.impactAudio.PlayImpactClip("G2", GetComponent<AudioSource>());
                        AudioManager.instance.impactAudio.PlayRandomImpactClip(audioSource);
                    }

                }
            }

        }

        public void OnCollisionEnter(Collision collision)
        {
            collisionRef = collision;
            isCollided = true;
            trigger();
        }

        public void trigger()
        {
            Debug.Log(PhotonNetwork.Time);
            triggerTime = PhotonNetwork.Time;
        }
        
    }
}

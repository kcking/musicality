using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Foundry
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundObject : MonoBehaviour, Photon.Pun.IPunObservable
    {
        double? triggerTime;
        double? lastSentTriggerTime;
        double? playedTime;
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

        void Start()
        {
            // InvokeRepeating("triggerLoop", 0, 2);
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
                    //  play it!
                    playedTime = triggerTime;
                    // AudioManager.instance.impactAudio.PlayImpactClip("G2", GetComponent<AudioSource>());
                    AudioManager.instance.impactAudio.PlayRandomImpactClip(GetComponent<AudioSource>());
                }
            }

        }

        public void OnCollisionEnter()
        {
            
        }
        

        public void trigger()
        {
            Debug.Log(PhotonNetwork.Time);
            triggerTime = PhotonNetwork.Time;
        }
    }
}

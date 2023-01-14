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
        double? playedTime;
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(triggerTime);
            }
            else if (stream.IsReading)
            {
                triggerTime = (double)stream.ReceiveNext();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("triggerLoop", 0, 2);
        }

        void triggerLoop()
        {
            // GetComponent<AudioSource>().Play();
            trigger();
        }

        // Update is called once per frame
        void Update()
        {
            if (triggerTime != null)
            {
                if (playedTime != triggerTime)
                {
                    //  play it!
                    playedTime = triggerTime;
                    AudioManager.instance.impactAudio.PlayImpactClip("G2", GetComponent<AudioSource>());
                }
            }

        }

        public void trigger()
        {
            Debug.Log(PhotonNetwork.Time);
            triggerTime = PhotonNetwork.Time;
        }
    }
}

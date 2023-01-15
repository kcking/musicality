using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

namespace Foundry
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject spawnObject;
        public float spawnRate;
        private Vector3 spawnLoc = new Vector3(-3.36f, 1.8f, 0);
        public float spawnVelocity = 10f;


        // Start is called before the first frame update
        void SpawnObject()
        {
            GameObject spawnedObject = PhotonNetwork.Instantiate(spawnObject.name, spawnLoc, Quaternion.identity);
            //Instantiate(spawnObject, spawnLoc, Quaternion.identity);
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * spawnVelocity, ForceMode.Impulse);
        }


        void Start()
        {
            InvokeRepeating("SpawnObject", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

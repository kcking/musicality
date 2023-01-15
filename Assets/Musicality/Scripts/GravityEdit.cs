using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class GravityEdit : MonoBehaviour
    {
        public float gravityPower = 1;
        public float minGravity = -5;
        public float maxGravity = 4;
        public bool randomGravity;
        // Start is called before the first frame update
        void Start()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if(randomGravity){

                rb.AddForce(Vector3.up * Random.Range(minGravity, maxGravity), ForceMode.Force);  
            }
            else{

                rb.AddForce(Vector3.up * gravityPower, ForceMode.Force);  
            }

        
        }
    }
}

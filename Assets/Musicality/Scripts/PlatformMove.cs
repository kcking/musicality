using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class PlatformMove : MonoBehaviour
    {
        // Start is called before the first frame update
        public float speed = 10f;
        void Start()
        {
        
        }

        // Update is called once per frame
    void Update(){

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y > 3){
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    }
}

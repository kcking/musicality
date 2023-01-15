using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class OutOfBounds : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if ((transform.position.x > 10 || transform.position.x < -10) || ((transform.position.z > 10 || transform.position.z < -10))){
                DestroyImmediate(gameObject);
            }
        
        }
    }
}

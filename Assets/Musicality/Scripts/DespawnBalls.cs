using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

namespace Foundry
{
    public class DespawnBalls : MonoBehaviour
    {
        
        void Update()
        {
            if(transform.position.x > 8.00 || transform.position.x < -8.00 || transform.position.z > 8.00 || transform.position.z < -8.00)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}

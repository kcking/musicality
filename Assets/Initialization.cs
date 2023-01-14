using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Foundry
{
    public class Initialization : MonoBehaviour
    {
        public UnityEvent startEvent;

        void Start()
        {
            startEvent.Invoke();
        }
        
    }
}

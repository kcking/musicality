using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Foundry
{
    public class GameManager : MonoBehaviour
    {
        // Events to include in the start method for initialization
        public UnityEvent startEvents;
        
        void Start()
        {
            startEvents.Invoke();
        }


    }
}

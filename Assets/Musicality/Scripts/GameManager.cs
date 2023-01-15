using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Foundry
{
    public class GameManager : MonoBehaviour
    {
        // Total available notes (strings)

        public static string[] allAvailableNotes = {"Eb2", "E2", "F2", "Gb2", "G2", "Ab2", "A2", "Bb2", "B2", "C3", "Db3", "D3", "Eb3", "E3", "F3", "Gb3", "G3", "Ab3", "A3", "Bb3", "B3"};

        public static List<string> currentAvailableNotes;

        // Events to include in the start method for initialization
        public UnityEvent startEvents;


        [SerializeField]
        private bool isOnQuest;

        void Awake()
        {
            currentAvailableNotes = null;
        }
        
        void Start()
        {
            if(!isOnQuest)
            {
                startEvents.Invoke();
            }
        }


    }
}

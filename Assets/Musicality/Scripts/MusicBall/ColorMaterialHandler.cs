using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Foundry
{
    public class ColorMaterialHandler : MonoBehaviour
    {
        private GameManager gameManager;

        public List<Material> colorMaterials;

        public Dictionary<string, Material> MaterialDict;

        private string[] notesInOctave = {"C", };

        void Awake()
        {
            FindObjectOfType<GameManager>();
        }

        void Start()
        {
            int index = 0;
            // foreach(Material mat in MaterialDict)
            // {
            //     MaterialDict.Add(notesInOctave[index], colorMaterials[index]);
            // }
        }


    }
}

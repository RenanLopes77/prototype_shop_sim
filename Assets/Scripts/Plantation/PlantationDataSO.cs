using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Plantation
{  
    [Serializable]
    public class Plant
    {
        public List<Sprite> Stages = new();
        public GameObject Prefab = null;
        public float TimePerStage = 0;
    }
    
    [CreateAssetMenu(fileName = "PlantationData", menuName = "Scriptable Objects/PlantationData")]
    public class PlantationDataSO : ScriptableObject
    {
        public List<Plant> Plants = new List<Plant>();

        public Plant GetRandom()
        {
            return Plants[UnityEngine.Random.Range(0, Plants.Count)];
        }
    }
}

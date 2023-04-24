using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Clothes
{
    [CreateAssetMenu(fileName = "ClothesData", menuName = "Scriptable Objects/ClothesData", order = 0)]
    public class ClothesDataSO : ScriptableObject
    {
        public List<Clothing> Clothes = new ();

        public Clothing GetByName(string name)
        {
            return Clothes.Find(clothing => clothing.Name.ToLower() == name.ToLower());
        }
    }
}

using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Clothes
{
    [CreateAssetMenu(fileName = "ClothesCatalog", menuName = "Scriptable Objects/ClothesCatalog", order = 0)]
    public class ClothesCatalogSO : ScriptableObject
    {
        [SerializeField] public ClothesDataSO Skins = null;
        [SerializeField] public ClothesDataSO Shirts = null;
        [SerializeField] public ClothesDataSO Pants = null;
        [SerializeField] public ClothesDataSO Hairs = null;
        [SerializeField] public ClothesDataSO Shoes = null;

        public List<Clothing> GetClothes(List<string> names)
        {
            Dictionary<string, ClothesDataSO> keywords = new Dictionary<string, ClothesDataSO>
            {
                { "skin", Skins },
                { "shirt", Shirts },
                { "pants", Pants },
                { "hair", Hairs },
                { "shoe", Shoes }
            };

            return names.Select(name =>
            {
                string nameLower = name.ToLower();
                foreach (KeyValuePair<string, ClothesDataSO> entry in keywords)
                {
                    if (nameLower.Contains(entry.Key))
                    {
                        return entry.Value.GetByName(name);
                    }
                }
                return null;
            })
            .Where(clothing => clothing != null)
            .ToList();
        }

        public Clothing GetRandom(ClothesDataSO clothesData)
        {
            var total = clothesData.Clothes.Count;
            return clothesData.Clothes[Random.Range(0, total)];
        }

        public List<Clothing> GetDefaultClothes()
        {
            List<Clothing> clothes = new()
            {
                GetRandom(Skins),
                GetRandom(Shirts),
                GetRandom(Pants),
                GetRandom(Hairs),
                GetRandom(Shoes)
            };
            return clothes;
        }
    }
}

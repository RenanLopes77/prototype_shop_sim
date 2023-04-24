using UnityEngine;

namespace Prototype.Items
{
    [CreateAssetMenu(fileName = "ItemsData", menuName = "Scriptable Objects/ItemsData")]
    public class ItemsDataSO : ScriptableObject
    {
        public Item[] Items = {};

        public Item GetByName(string name)
        {
            foreach (var item in Items)
            {
                if (item.Name.ToLower() == name.ToLower()) return item;
            }

            return null;
        }
    }
}

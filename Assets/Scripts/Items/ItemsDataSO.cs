using UnityEngine;

namespace Prototype.Items
{
    [CreateAssetMenu(fileName = "ItemsData", menuName = "Scriptable Objects/ItemsData")]
    public class ItemsDataSO : ScriptableObject
    {
        public Item[] Items = {};
    }
}

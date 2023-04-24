using UnityEngine;
using Prototype.Inventory;

namespace Prototype.Plantation
{
    public class PlantationItem : MonoBehaviour
    {
        [SerializeField] private string _itemName = string.Empty;
        [SerializeField] private Collider2D _collider = null;

        public void OnInteract()
        {
            if (InventorySystem.CheckItemFits(InventoryKeys.ITEMS))
            {
                InventorySystem.AddName(InventoryKeys.ITEMS, _itemName);
                _collider.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}

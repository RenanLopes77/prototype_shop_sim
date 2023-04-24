using UnityEngine;
using Prototype.Inventory;
using UnityEngine.Events;

namespace Prototype.Plantation
{
    public class PlantationItem : MonoBehaviour
    {
        [SerializeField] private string _itemName = string.Empty;
        [HideInInspector] public UnityEvent OnCollect = new ();

        private void OnDestroy()
        {
            OnCollect.RemoveAllListeners();    
        }

        public void OnInteract()
        {
            if (InventorySystem.CheckItemFits(InventoryKeys.ITEMS))
            {
                InventorySystem.AddName(InventoryKeys.ITEMS, _itemName);
                OnCollect?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}

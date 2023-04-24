using Prototype.Inventory;
using Prototype.Items;
using UnityEngine;

namespace Prototype.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventoryItemUI _inventoryItemUIPrefab = null;
        [SerializeField] private Transform _content = null;
        [SerializeField] private ItemsDataSO _itemsData = null;
        
        private void Start()
        {
            SpawnInventoryItems();
            InventorySystem.OnItemsChange.AddListener(SpawnInventoryItems);
        }

        private void OnDestroy()
        {
            InventorySystem.OnItemsChange.RemoveListener(SpawnInventoryItems);
        }

        private void SpawnInventoryItems()
        {
            DestroyContentChildren();
            var itemNames = InventorySystem.GetNames(InventoryKeys.ITEMS);
            itemNames.ForEach(
                name =>
                {
                    var item = _itemsData.GetByName(name);
                    var itemUI = Instantiate(_inventoryItemUIPrefab, _content);
                    itemUI.Set(item);
                }
            );
        }

        private void DestroyContentChildren()
        {
            foreach (Transform child in _content)
            {
                Destroy(child.gameObject);
            }
        }
    }
}

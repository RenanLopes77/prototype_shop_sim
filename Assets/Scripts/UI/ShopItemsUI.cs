using UnityEngine;
using Prototype.Items;

namespace Prototype.UI
{
    public class ShopItemsUI : MonoBehaviour
    {
        [SerializeField] private ShopItemUI _itemUIPrefab = null;
        [SerializeField] private Transform _content = null;
        [SerializeField] private ItemsDataSO _itemsData = null;

        private void OnEnable()
        {
            InstantiateItems();
        }

        private void OnDisable()
        {
            DestroyContentChildren();   
        }

        private void InstantiateItems()
        {
            foreach (var item in _itemsData.Items)
            {
                var itemUI = Instantiate(_itemUIPrefab, _content);
                itemUI.SetData(item);
            }
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

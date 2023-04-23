using UnityEngine;
using Prototype.Items;

namespace Prototype.UI
{
    public class ItemsUI : MonoBehaviour
    {
        [SerializeField] private ItemUI _itemUIPrefab = null;
        [SerializeField] private Transform _content = null;
        [SerializeField] private ItemsDataSO _itemsData = null;
        
        private void Start()
        {
            InstantiateItems();
        }

        private void InstantiateItems()
        {
            foreach (var item in _itemsData.Items)
            {
                var itemUI = Instantiate(_itemUIPrefab, _content);
                itemUI.SetData(item);
            }
        }
    }
}

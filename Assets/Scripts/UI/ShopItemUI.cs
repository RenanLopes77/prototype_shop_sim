using UnityEngine;
using UnityEngine.UI;
using Prototype.Items;
using Prototype.Money;
using Prototype.Utils;
using Prototype.Inventory;
using TMPro;

namespace Prototype.UI
{
    public class ShopItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image = null;
        [SerializeField] private TextMeshProUGUI _name = null;
        [SerializeField] private TextMeshProUGUI _price = null;
        [SerializeField] private GameObject _sellButton = null;
        private Item _item = null;

        private void OnEnable()
        {
            if (_item == null) return;
            CheckCanAfford();
            CheckCanSell();
        }

        private void OnDestroy()
        {
            MoneySystem.OnValueChange.RemoveListener(CheckCanAfford);
            InventorySystem.OnItemsChange.RemoveListener(CheckCanSell);
        }
        
        public void SetData(Item item)
        {
            _item = item;
            _image.sprite = _item.Sprite;
            _name.SetText(_item.Name);
            _price.SetText(_item.Price.ToString());
            CheckCanAfford();
            CheckCanSell();
            MoneySystem.OnValueChange.AddListener(CheckCanAfford);
            InventorySystem.OnItemsChange.AddListener(CheckCanSell);
        }

        private void CheckCanAfford()
        {
            if (MoneySystem.CanSpend(_item.Price))
            {
                _price.color = Color.black;
            }
            else
            {
                _price.color = Color.red;
            }
        }

        private void CheckCanSell()
        {
            var contains = InventorySystem.ContainsName(InventoryKeys.ITEMS, _item.Name);
            _sellButton.SetActive(contains);
        }

        public void OnClickBuy()
        {
            if (
                InventorySystem.CheckItemFits(InventoryKeys.ITEMS) &&
                MoneySystem.Spend(_item.Price)
            )
            {
                InventorySystem.AddName(InventoryKeys.ITEMS, _item.Name);
            }
        }

        public void OnClickSell()
        {
            InventorySystem.RemoveName(InventoryKeys.ITEMS, _item.Name);
            MoneySystem.Gain(_item.Price);
        }
    }
}

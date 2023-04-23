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
        [SerializeField] private CanvasGroup _canvasGroup = null;
        [SerializeField] private GameObject _sellButton = null;
        private Item _item = null;

        private void OnDestroy()
        {
            MoneySystem.OnValueChange.RemoveListener(CheckCanBuy);
            InventorySystem.OnItemsChange.RemoveListener(CheckCanSell);
        }
        
        public void SetData(Item item)
        {
            _item = item;
            _image.sprite = _item.Sprite;
            _name.SetText(_item.Name);
            _price.SetText(Format.Money(_item.Price));
            CheckCanBuy();
            CheckCanSell();
            MoneySystem.OnValueChange.AddListener(CheckCanBuy);
            InventorySystem.OnItemsChange.AddListener(CheckCanSell);
        }

        private void CheckCanBuy()
        {
            if (
                MoneySystem.CanSpend(_item.Price) &&
                InventorySystem.CheckItemFits(InventotyKeys.ITEMS)
            )
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
            var names = InventorySystem.GetNames(InventotyKeys.ITEMS);
            _sellButton.SetActive(names.Contains(_item.Name));
        }

        public void OnClickBuy()
        {
            if (MoneySystem.Spend(_item.Price))
            {
                InventorySystem.AddName(InventotyKeys.ITEMS, _item.Name);
            }
            else
            {
                Debug.Log($"NÃO CONSIGO COMPRAR");
            }
        }

        public void OnClickSell()
        {
            InventorySystem.RemoveName(InventotyKeys.ITEMS, _item.Name);
            MoneySystem.Gain(_item.Price);
        }
    }
}

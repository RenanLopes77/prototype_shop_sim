using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.Clothes;
using Prototype.Inventory;
using Prototype.Money;
using TMPro;

namespace Prototype.UI
{
    public class ShopClothingItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image = null;
        [SerializeField] private TextMeshProUGUI _price = null;
        [SerializeField] private GameObject _buyButton = null;
        [SerializeField] private GameObject _wearButton = null;
        private Clothing _clothing = null;

        private void OnDestroy()
        {
            MoneySystem.OnValueChange.RemoveListener(CheckCanAfford);
        }
        
        public void Set(Clothing clothing)
        {
            _clothing = clothing;
            _image.sprite = _clothing.Cover;
            _price.SetText(_clothing.Price.ToString());
            CheckIsPurchased();
            CheckCanAfford();
            MoneySystem.OnValueChange.AddListener(CheckCanAfford);
        }

        private void CheckCanAfford()
        {
            if (MoneySystem.CanSpend(_clothing.Price))
            {
                _price.color = Color.black;
            }
            else
            {
                _price.color = Color.red;
            }
        }

        private void CheckIsPurchased()
        {
            if (
                _clothing.Price == 0 ||
                InventorySystem.ContainsName(InventoryKeys.CLOTHES, _clothing.Name)
            )
            {
                _price.gameObject.SetActive(false);
                _buyButton.SetActive(false);
                _wearButton.SetActive(true);
            }
        }

        public void OnClickBuy()
        {
            if (MoneySystem.Spend(_clothing.Price))
            {
                InventorySystem.AddName(InventoryKeys.CLOTHES, _clothing.Name);
                OnClickWear();
                CheckIsPurchased();
            }
        }

        public void OnClickWear()
        {
            var names = InventorySystem.GetNames(InventoryKeys.CLOTHES_WEARING);

            Dictionary<ClothingType, string> keywords = new()
            {
                { ClothingType.SKIN, "skin" },
                { ClothingType.SHIRT, "shirt" },
                { ClothingType.PANTS, "pants" },
                { ClothingType.HAIR, "hair" },
                { ClothingType.SHOES, "shoe" }
            };

            names.ForEach(name =>
            {
                if (name.ToLower().Contains(keywords[_clothing.Type]))
                {
                    InventorySystem.RemoveName(InventoryKeys.CLOTHES_WEARING, name);
                    InventorySystem.AddName(InventoryKeys.CLOTHES_WEARING, _clothing.Name);
                }
            });
        }
    }
}

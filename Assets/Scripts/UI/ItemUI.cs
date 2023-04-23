using UnityEngine;
using UnityEngine.UI;
using Prototype.Items;
using Prototype.Money;
using Prototype.Utils;
using TMPro;

namespace Prototype.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image = null;
        [SerializeField] private TextMeshProUGUI _name = null;
        [SerializeField] private TextMeshProUGUI _price = null;
        [SerializeField] private CanvasGroup _canvasGroup = null;
        private Item _item = null;

        private void OnDestroy()
        {
            MoneySystem.OnValueChange.RemoveListener(CheckCanSpend);
        }
        
        public void SetData(Item item)
        {
            _item = item;
            _image.sprite = _item.Sprite;
            _name.SetText(_item.Name);
            _price.SetText(Format.Money(_item.Price));
            CheckCanSpend();
            MoneySystem.OnValueChange.AddListener(CheckCanSpend);
        }

        private void CheckCanSpend()
        {
            if (MoneySystem.CanSpend(_item.Price))
            {
                _canvasGroup.alpha = 1f;
                _canvasGroup.interactable = true;
                _price.color = Color.black;
            }
            else
            {
                _canvasGroup.alpha = .8f;
                _canvasGroup.interactable = false;
                _price.color = Color.red;
            }
        }

        public void OnClick()
        {
            if (MoneySystem.Spend(_item.Price))
            {
                Debug.Log($"ITEM COMPRADO");
            }
            else
            {
                Debug.Log($"NÃO CONSIGO COMPRAR");
            }
        }
    }
}

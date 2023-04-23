using Prototype.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.UI
{
    public class InventoryItemUI : MonoBehaviour {
        [SerializeField] private Image _image = null;
        public void Set(Item item)
        {
            _image.sprite = item.Sprite;
        }
    }
}

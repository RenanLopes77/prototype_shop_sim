using Prototype.Input;
using Prototype.Inventory;
using UnityEngine;

namespace Prototype.Player
{
    public class PlayerPlantation : MonoBehaviour
    {
        [SerializeField] private GameObject _seedlingPrefab = null;
        void Start()
        {
            HandleInput.Instance.AddKeyListener(Keys.PLANT, Plant);
        }

        private void OnDestroy()
        {
            HandleInput.Instance.AddKeyListener(Keys.PLANT, Plant);
        }

        private void Plant()
        {
            var names = InventorySystem.GetNames(InventoryKeys.ITEMS);
            if (names.Count > 0)
            {
                Instantiate(_seedlingPrefab, transform.position, Quaternion.identity);
                InventorySystem.RemoveName(InventoryKeys.ITEMS, names[0]);
            }
        }
    }
}

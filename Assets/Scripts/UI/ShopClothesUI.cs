using UnityEngine;
using Prototype.Clothes;

namespace Prototype.UI
{
    public class ShopClothesUI : MonoBehaviour
    {
        [SerializeField] private ShopClothingItemUI _clothingItemUIPrefab = null;
        [SerializeField] private ClothesCatalogSO _catalog = null;
        [SerializeField] private Transform _content = null;
        
        private void OnEnable()
        {
            LoadShirts();
        }

        private void LoadItemsUI(ClothesDataSO clothesData)
        {
            DestroyContentChildren();
            clothesData.Clothes.ForEach(
                clothing =>
                {
                    var shopItemUI = Instantiate(_clothingItemUIPrefab, _content);
                    shopItemUI.Set(clothing);
                }
            );
        }

        public void LoadShirts() => LoadItemsUI(_catalog.Shirts);
        public void LoadPants() => LoadItemsUI(_catalog.Pants);
        public void LoadShoes() => LoadItemsUI(_catalog.Shoes);
        public void LoadHairs() => LoadItemsUI(_catalog.Hairs);
        public void LoadSkins() => LoadItemsUI(_catalog.Skins);
        private void DestroyContentChildren()
        {
            foreach (Transform child in _content)
            {
                Destroy(child.gameObject);
            }
        }
    }
}

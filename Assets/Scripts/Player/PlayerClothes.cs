using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.Clothes;
using Prototype.Inventory;

namespace Prototype.Player
{
    public class PlayerClothes : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D = null;
        [SerializeField] private int _frame = 0;
        
        [Header("Body Parts")]
        [SerializeField] private SpriteRenderer _skin = null;
        [SerializeField] private SpriteRenderer _shirt = null;
        [SerializeField] private SpriteRenderer _pants = null;
        [SerializeField] private SpriteRenderer _hair = null;
        [SerializeField] private SpriteRenderer _Shoes = null;

        [Header("Clothes")]
        [SerializeField] private ClothesCatalogSO _catalog = null;
        private List<Clothing> _clothes = new();

#region Lifecycle
        
        private void Awake()
        {
            if (InventorySystem.GetNames(InventotyKeys.CLOTHES_WEARING).Count == 0)
            {
                var clothes = _catalog.GetDefaultClothes();
                clothes.ForEach(clothing =>
                {
                    InventorySystem.AddName(InventotyKeys.CLOTHES, clothing.Name);
                    InventorySystem.AddName(InventotyKeys.CLOTHES_WEARING, clothing.Name);
                });
            }
        }

        private void Start()
        {
            LoadClothes();
            InventorySystem.OnClothesWearingChange.AddListener(LoadClothes);
        }

        private void Update()
        {
            _clothes.ForEach(SetClothes);
        }

        private void OnDestroy()
        {
            InventorySystem.OnClothesWearingChange.RemoveListener(LoadClothes);
        }

#endregion
#region Private Methods

        private void LoadClothes()
        {
            var names = InventorySystem.GetNames(InventotyKeys.CLOTHES_WEARING);
            _clothes = _catalog.GetClothes(names);
        }

        private void SetClothes(Clothing clothing)
        {
            var direction = GetClothingDirection();
            var frames = clothing.GetFrames(direction);
            if (frames.Length <= _frame) return;
            var frame = frames[_frame];
            
            switch(clothing.Type)
            {
                case ClothingType.SKIN:
                    _skin.sprite = frame;
                    break;
                case ClothingType.HAIR:
                    _hair.sprite = frame;
                    break;
                case ClothingType.PANTS:
                    _pants.sprite = frame;
                    break;
                case ClothingType.SHIRT:
                    _shirt.sprite = frame;
                    break;
                case ClothingType.SHOES:
                    _Shoes.sprite = frame;
                    break;
            }
        }

        private ClothingDirection GetClothingDirection() 
        {
            var vel = _rigidbody2D.velocity;
            if (vel.sqrMagnitude == 0) return ClothingDirection.IDLE;
            if (vel.x >= 0.01f || vel.x <= -0.01f) return ClothingDirection.SIDEWAY;
            if (vel.y > 0) return ClothingDirection.UP;
            return ClothingDirection.DOWN;
        }

#endregion
    }
}

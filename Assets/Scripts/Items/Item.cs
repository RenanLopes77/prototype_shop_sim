using System;
using UnityEngine;
using NaughtyAttributes;

namespace Prototype.Items
{
    [Serializable]
    public class Item {
        public string Name = string.Empty;
        public int Price = 0;
        [ShowAssetPreview(256, 256)] public Sprite Sprite = null;
    }
}

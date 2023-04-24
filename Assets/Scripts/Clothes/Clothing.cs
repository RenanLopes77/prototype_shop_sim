using System;
using NaughtyAttributes;
using UnityEngine;

namespace Prototype.Clothes
{
    public enum ClothingType
    {
        NONE = 0,
        SKIN = 1,
        HAIR = 2,
        PANTS = 3,
        SHIRT = 4,
        SHOES = 5,
    }

    public enum ClothingDirection
    {
        NONE = 0,
        IDLE = 1,
        UP = 2,
        DOWN = 3,
        SIDEWAY = 4,
    }

    [Serializable]
    public class Clothing
    {
        public string Name = string.Empty;
        public ClothingType Type = ClothingType.NONE;
        public int Price = 0;
        [ShowAssetPreview(256, 256)] public Sprite Cover = null;

        [Header("Frames")]
        public Sprite[] IdleFrames = null;
        public Sprite[] UpFrames = null;
        public Sprite[] DownFrames = null;
        public Sprite[] SideFrames = null;

        public Sprite[] GetFrames(ClothingDirection direction)
        {
            return direction switch
            {
                ClothingDirection.IDLE => IdleFrames,
                ClothingDirection.UP => UpFrames,
                ClothingDirection.DOWN => DownFrames,
                ClothingDirection.SIDEWAY => SideFrames,
                _ => new Sprite[] { },
            };
        }
    }
}

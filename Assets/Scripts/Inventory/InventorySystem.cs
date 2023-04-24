using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype.Inventory
{
    public class InventoryKeys
    {
        public const string ITEMS = "inventory_items";
        public const string CLOTHES = "inventory_clothes";
        public const string CLOTHES_WEARING = "inventory_clothes_Wearing";
    }
    
    public class InventorySystem
    {
        private const string SEPARATOR = "$$$";
        private const int MAXIMUM_ITEMS = 5;

        public static UnityEvent OnItemsChange {get; private set;} = new();
        public static UnityEvent OnClothesWearingChange {get; private set;} = new();

        public static bool CheckItemFits(string key)
        {
            var size = GetNames(key).Count;
            return size < MAXIMUM_ITEMS;
        }

        public static void AddName(string key, string name)
        {
            var names = GetNames(key);
            names.Add(name.ToLower());
            Save(key, names);
        }

        public static void RemoveName(string key, string name)
        {
            var names = GetNames(key);
            names.Remove(name.ToLower());
            Save(key, names);
        }

        private static void Save(string key, List<string> names)
        {
            var fullString = string.Join(SEPARATOR, names);
            PlayerPrefs.SetString(key, fullString);
            InventoryChanged(key);
        }

        private static void InventoryChanged(string key)
        {
            switch(key)
            {
                case InventoryKeys.ITEMS:
                    OnItemsChange?.Invoke();
                    break;
                case InventoryKeys.CLOTHES_WEARING:
                    OnClothesWearingChange?.Invoke();
                    break;
            }
        }

        public static List<string> GetNames(string key)
        {
            var names = PlayerPrefs.GetString(key, string.Empty).Split(SEPARATOR).ToList();
            names.Remove(string.Empty);
            return names;
        }

        public static bool ContainsName(string key, string name)
        {
            return GetNames(key).Contains(name.ToLower());
        }
    }
}

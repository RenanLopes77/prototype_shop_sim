using UnityEngine;

namespace Prototype.Money {
    public static class MoneySystem
    {
        private static readonly string MONEY_KEY = "money";
        public static bool CanSpend(int value) => value <= GetValue();
        public static void Gain(int value) => SetValue(GetValue() + value);
        public static int GetValue() => PlayerPrefs.GetInt(MONEY_KEY, 0);
        private static void SetValue(int value) => PlayerPrefs.SetInt(MONEY_KEY, value);
        public static bool Spend(int value)
        {
            if (CanSpend(value))
            {
                var current = GetValue();
                SetValue(current - value);
                return true;
            }
            return false;
        }
    }
}

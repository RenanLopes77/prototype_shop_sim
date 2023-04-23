using UnityEngine;
using UnityEngine.Events;

namespace Prototype.Money {
    public static class MoneySystem
    {
        private static readonly string MONEY_KEY = "money";
        private static readonly int INITIAL_VALUE = 250;
        public static UnityEvent OnValueChange {get; private set;} = new();
        
        public static bool CanSpend(int value) => value <= GetValue();
        public static void Gain(int value) => SetValue(GetValue() + value);
        public static int GetValue() => PlayerPrefs.GetInt(MONEY_KEY, INITIAL_VALUE);
        
        private static void SetValue(int value)
        {
            PlayerPrefs.SetInt(MONEY_KEY, value);
            OnValueChange?.Invoke();
        }
        
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

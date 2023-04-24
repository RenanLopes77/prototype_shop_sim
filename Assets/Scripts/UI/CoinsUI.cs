using UnityEngine;
using TMPro;
using Prototype.Money;
using Prototype.Utils;

namespace Prototype.UI
{
    public class CoinsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins = null;
        private void Start()
        {
            UpdateCoinsText();
            MoneySystem.OnValueChange.AddListener(UpdateCoinsText);
        }

        private void OnDestroy()
        {
            MoneySystem.OnValueChange.RemoveListener(UpdateCoinsText);
        }

        private void UpdateCoinsText()
        {
            _coins.SetText(MoneySystem.GetValue().ToString());
        }
    }
}

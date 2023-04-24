using UnityEngine.Events;

namespace Prototype.Input
{
    public static class Keys
    {
        public const string INTERACT = "Interact";
        public const string PLANT = "Plant";
    }

    public class Key
    {
        public string Name { get; private set; } = string.Empty;
        private UnityEvent _onPress = new();
        private UnityEvent _onRelease = new();

        public Key(string name, UnityAction onPress = null, UnityAction onRelease = null)
        {
            Name = name;
            AddListeners(onPress, onRelease);
        }

        public void AddListeners(UnityAction onPress = null, UnityAction onRelease = null)
        {
            if (onPress != null) _onPress.AddListener(onPress);
            if (onRelease != null) _onRelease.AddListener(onRelease);
        }

        public void RemoveListeners(UnityAction onPress = null, UnityAction onRelease = null)
        {
            if (onPress != null) _onPress.RemoveListener(onPress);
            if (onRelease != null) _onRelease.RemoveListener(onRelease);
        }

        public void HandleKey()
        {
            if (UnityEngine.Input.GetButtonDown(Name)) _onPress?.Invoke();
            if (UnityEngine.Input.GetButtonUp(Name)) _onRelease?.Invoke();
        }

        public void RemoveAllListeners()
        {
            _onPress.RemoveAllListeners();
            _onRelease.RemoveAllListeners();
            _onPress = null;
            _onRelease = null;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype.Input
{
    public class HandleInput : MonoBehaviour
    {
        private Vector2 _axisValues = Vector2.zero;
        public List<Key> _keys = new();
        public List<UnityAction<Vector2>> _axisListeners = new();

#region Singleton

        private static HandleInput _instance = null;
        public static HandleInput Instance
        {
            get
            {
                if (_instance == null)
                {
                    var inputGO = new GameObject("@Input");
                    _instance = inputGO.AddComponent<HandleInput>();
                }
                return _instance;
            }
        }

#endregion
#region Lifecycle

        private void Update()
        {
            for (int i = _keys.Count - 1; i >= 0; i--)
            {
                _keys[i]?.HandleKey();
            }
        }

        private void FixedUpdate()
        {
            _axisListeners.ForEach(listener => listener.Invoke(Axis.GetValues(_axisValues)));
        }

        private void OnDestroy()
        {
            RemoveAllListeners();
        }

#endregion
#region Public Methods
        
        public void AddAxisListener(UnityAction<Vector2> listener)
        {
            _axisListeners.Add(listener);
        }

        public void RemoveAxisListener(UnityAction<Vector2> listener)
        {
            _axisListeners.Remove(listener);
        }
        
        public void AddKeyListener(string name, UnityAction onPress = null, UnityAction onRelease = null)
        {
            var key = _keys.FirstOrDefault(key => key.Name == name);
            if (key == null)
            {
                key = new Key(name, onPress, onRelease);
                _keys.Add(key);
            }
            else
            {
                key.AddListeners(onPress, onRelease);
            }
        }

        public void RemoveKeyListener(string name, UnityAction onPress = null, UnityAction onRelease = null)
        {
            var key = _keys.FirstOrDefault(key => key.Name == name);
            if (key == null) return;
            key.RemoveListeners(onPress, onRelease);
            _keys.Remove(key);
        }

#endregion
#region Private Methods

        private void RemoveAllListeners()
        {
            _keys.ForEach(key => key.RemoveAllListeners());
            _keys.Clear();
            _axisListeners.Clear();
        }

#endregion

    }
}

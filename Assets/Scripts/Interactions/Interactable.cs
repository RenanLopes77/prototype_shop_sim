using UnityEngine;
using UnityEngine.Events;

namespace Prototype.Interaction
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onEnterRange = new();
        [SerializeField] private UnityEvent _onExitRange = new();
        [SerializeField] private UnityEvent _onInteract = new();
        public void OnEnterRange() => _onEnterRange?.Invoke();
        public void OnExitRange() => _onExitRange?.Invoke();
        public void OnInteract() => _onInteract?.Invoke();
    }
}

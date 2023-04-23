using NaughtyAttributes;
using Prototype.Interaction;
using Prototype.Input;
using UnityEngine;

namespace Prototype.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject _interactableIndicator = null;
        [Tag][SerializeField] private string _interactableTag = string.Empty;
        private GameObject _indicatorGO = null;
        private Interactable _interactable = null;

#region Lifecycle
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!IsInteractable(collider)) return;
            SpawnIndicator(collider.ClosestPoint(transform.position));
            _interactable.OnEnterRange();
            HandleInput.Instance.AddKeyListener(Keys.INTERACT, _interactable.OnInteract);
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (!IsInteractable(collider)) return;
            HandleInput.Instance.RemoveKeyListener(Keys.INTERACT, _interactable.OnInteract);
            _interactable.OnExitRange();
            DestroyIndicator();
            RemoveInteractable();
        }

#endregion
#region Private Methods

        private bool IsInteractable(Collider2D collider)
        {
            if (!collider.CompareTag(_interactableTag)) return false;
            if (!collider.TryGetComponent(out Interactable interactable)) return false;
            SetInteractable(interactable);
            return true;
        }

        private void SetInteractable(Interactable interactable)
        {
            _interactable ??= interactable;
        }
        
        private void RemoveInteractable()
        {
            if (_interactable == null) return;
            _interactable = null;
        }

        private void SpawnIndicator(Vector2 position)
        {
            if (_indicatorGO != null) return;
            position.y += 1.5f;
            _indicatorGO = Instantiate(_interactableIndicator, position, Quaternion.identity);
        }

        private void DestroyIndicator() => Destroy(_indicatorGO);

#endregion

    }
}

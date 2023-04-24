using Prototype.Input;
using UnityEngine;

namespace Prototype.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody2D = null;

        private void Awake()
        {
            HandleInput.Instance.AddAxisListener(Move);
        }

        private void OnDestroy()
        {
            HandleInput.Instance.RemoveAxisListener(Move);
        }

        private void Move(Vector2 axis)
        {
            _rigidbody2D.velocity = axis;
            _rigidbody2D.velocity *= _speed;
        }
    }
}

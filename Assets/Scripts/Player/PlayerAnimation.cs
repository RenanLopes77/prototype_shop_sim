using UnityEngine;

namespace Prototype.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private Rigidbody2D _rigidbody2D = null;
        private Vector3 _localScale = Vector3.zero;
        
        private void Update()
        {           
            _animator.SetFloat("Horizontal", _rigidbody2D.velocity.x);
            _animator.SetFloat("Vertical", _rigidbody2D.velocity.y);
            SetLocalScale();
        }

        private void SetLocalScale()
        {
            _localScale = transform.localScale;
            if (_rigidbody2D.velocity.x >= 0) _localScale.x = 1;
            else  _localScale.x = -1;
            transform.localScale = _localScale;
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody2D _rigidbody2D = null;

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Input.Instance.GetAxis();
        _rigidbody2D.velocity *= _speed;
    }
}

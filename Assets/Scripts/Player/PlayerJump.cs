using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private float _castDistance;
    [SerializeField] private float _jumpForce; //25
    [SerializeField] private Transform _checkGround;
    public float gravityScale = 10; //10
    public float fallingGravityScale = 40; //10
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGround())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        if (_rigidbody.velocity.y >= 0)
        {
            _rigidbody.gravityScale = gravityScale;
        }
        else if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.gravityScale = fallingGravityScale;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_checkGround.position, _boxSize);
    }
    public bool IsGround()
    {
        return Physics2D.OverlapBox(_checkGround.position, _boxSize, 0, _layerGround);
    }
}

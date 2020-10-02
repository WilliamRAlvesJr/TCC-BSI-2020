using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const float Tolerance = 0.1f;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 _oldPos;
    private const float Speed = 6;
    private Vector2 _newVelocity;
    private static readonly int Walking = Animator.StringToHash("Walking");

    private void Start()
    {
        _oldPos = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if(Math.Abs(_oldPos.x - transform.position.x) > Tolerance || Math.Abs(_oldPos.y - transform.position.y) > Tolerance)
        {
            _animator.SetBool(Walking, true);
        }
        else
        {
            _animator.SetBool(Walking, false);
        }
        _oldPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _newVelocity = Speed * Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _newVelocity = Speed * Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _newVelocity = Speed * Vector2.left;
            _spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _newVelocity = Speed * Vector2.right;
            _spriteRenderer.flipX = false;
        }

        _rigidbody2D.velocity = _newVelocity;
    }
}
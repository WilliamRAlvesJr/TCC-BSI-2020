using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    private const float Tolerance = 0.1f;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 _oldPos;
    public static float Speed = 6;
    public static Vector2 NewVelocity;
    private static readonly int Walking = Animator.StringToHash("Walking");
    private AudioSource _stepsAudioSource;
    private float _lastStepTime = 0f;

    private void Start()
    {
        _oldPos = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _stepsAudioSource = GetComponents<AudioSource>()[0];
    }

    private void FixedUpdate()
    {
        if(Math.Abs(_oldPos.x - transform.position.x) > Tolerance || Math.Abs(_oldPos.y - transform.position.y) > Tolerance)
        {
            _animator.SetBool(Walking, true);
            if (_stepsAudioSource.isPlaying) return;
            
            if (Time.time > _lastStepTime) 
            {
                _stepsAudioSource.Play();
                _lastStepTime = Time.time + 0.5f;
            }
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
            NewVelocity = Speed * Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            NewVelocity = Speed * Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            NewVelocity = Speed * Vector2.left;
            _spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            NewVelocity = Speed * Vector2.right;
            _spriteRenderer.flipX = false;
        }

        _rigidbody2D.velocity = NewVelocity;
    }
}
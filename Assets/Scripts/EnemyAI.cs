using UnityEngine;
using Random = System.Random;

public class EnemyAI : MonoBehaviour
{
    private Vector2 _newVelocity;
    private const float Speed = 10;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var randomNumber = new Random().Next(1, 51);

        if (randomNumber == 1)
            _newVelocity = Speed * Vector2.up;
        else if (randomNumber == 2)
            _newVelocity = Speed * Vector2.down;
        else if (randomNumber == 3)
            _newVelocity = Speed * Vector2.left;
        else if (randomNumber == 4)
            _newVelocity = Speed * Vector2.right;

        _rigidbody2D.velocity = _newVelocity;
    }
    
}
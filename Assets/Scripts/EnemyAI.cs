using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class EnemyAI : MonoBehaviour
{
    private Vector2 _newVelocity;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var randomNumber = new Random().Next(1, 51);

        if (randomNumber == 1)
            _newVelocity = speed * Vector2.up;
        else if (randomNumber == 2)
            _newVelocity = speed * Vector2.down;
        else if (randomNumber == 3)
            _newVelocity = speed * Vector2.left;
        else if (randomNumber == 4)
            _newVelocity = speed * Vector2.right;

        _rigidbody2D.velocity = _newVelocity;
    }
    
}
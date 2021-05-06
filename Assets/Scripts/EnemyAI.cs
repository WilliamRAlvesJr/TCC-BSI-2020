using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using static RageModeController;
using Random = System.Random;

public class EnemyAI : MonoBehaviour
{
    private Vector2 _newVelocity;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;
    private Light2D _light;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _light = GetComponentInChildren<Light2D>();
    }

    private void Update()
    {
        var randomNumber = new Random().Next(1, 51);

        if (randomNumber == 1)
            _newVelocity = speed * GameSpeedController.GameSpeed * Vector2.up;
        else if (randomNumber == 2)
            _newVelocity = speed * GameSpeedController.GameSpeed * Vector2.down;
        else if (randomNumber == 3)
            _newVelocity = speed * GameSpeedController.GameSpeed * Vector2.left;
        else if (randomNumber == 4)
            _newVelocity = speed * GameSpeedController.GameSpeed * Vector2.right;

        _rigidbody2D.velocity = _newVelocity;
        
        if (IsOnRageMode && _light.color.Equals(Color.red))
            _light.color = Color.blue;
        else if (!IsOnRageMode && _light.color.Equals(Color.blue))
            _light.color = Color.red;
    }
    
}
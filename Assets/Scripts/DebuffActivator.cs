using System.Collections;
using UnityEngine;

public class DebuffActivator : MonoBehaviour
{
    [SerializeField] private Material _redOutlineMaterial;
    [SerializeField] private Material _defaultSpriteMaterial;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !other.name.Equals("PlayerCollider")) return;
        
        PlayerMovementController.NewVelocity = Vector2.zero;
        PlayerMovementController.Speed = 0f;
        
        _spriteRenderer.material = _redOutlineMaterial;
     
        StartCoroutine(RebuffCooldDown());
    }

    private IEnumerator RebuffCooldDown()
    {
        yield return new WaitForSeconds(3f);
        
        PlayerMovementController.Speed = 6f;
        _spriteRenderer.material = _defaultSpriteMaterial;
        Destroy(gameObject);        
    }
}
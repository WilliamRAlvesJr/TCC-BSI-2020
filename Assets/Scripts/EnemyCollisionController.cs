using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name.Equals("PlayerCollider"))
        {
            GameObject objToDestroy = null;
            if (RageModeController.IsOnRageMode)
            {
                objToDestroy = transform.parent.gameObject;
            }
            else
            {
                objToDestroy = other.gameObject;
            }
            
            var explosionInScene = Instantiate(explosionPrefab);
            explosionInScene.transform.position = objToDestroy.transform.position + Vector3.up;
            
            Destroy(objToDestroy);
        }
    }
}

using System.Collections;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    
    private void Start()
    {
        StartCoroutine(ActiveRageMode());
    }

    private IEnumerator ActiveRageMode()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
    
}

using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using static RageModeController;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeToSpawn = 15;

    private void Start()
    {
        StartCoroutine(enableRespawn());
    }

    private IEnumerator enableRespawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
        var newEnemy = Instantiate(enemy);
        newEnemy.transform.position = transform.position;
        StartCoroutine(enableRespawn());
    } 
}

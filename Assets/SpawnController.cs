using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        StartCoroutine(enableRespawn());
    }

    private IEnumerator enableRespawn()
    {
        yield return new WaitForSeconds(15f);
        Instantiate(enemy).transform.position = transform.position;
        StartCoroutine(enableRespawn());
    } 
}

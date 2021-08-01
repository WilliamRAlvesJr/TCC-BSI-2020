using System.Collections;
using UnityEngine;

public class ChangeSceneAfterSeconds : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(52f);
        NavigationManager.NavigateTo("MainMenu");
    }
}

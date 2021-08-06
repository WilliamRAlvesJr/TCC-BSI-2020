using System.Collections;
using UnityEngine;

public class ChangeSceneAfterSeconds : MonoBehaviour
{
    [SerializeField]
    private float secondsToChange = 52;

    private void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(secondsToChange);
        NavigationManager.NavigateTo("MainMenu");
    }
}

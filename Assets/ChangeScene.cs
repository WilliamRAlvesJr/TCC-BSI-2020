using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void Change(string name)
    {
        SceneManager.LoadScene(name);
    }
}

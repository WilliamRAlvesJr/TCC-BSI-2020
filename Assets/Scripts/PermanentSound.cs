using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentSound : MonoBehaviour
{
    [SerializeField] private AudioSource tutorialAudioSource;
    
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Tutorial") && !tutorialAudioSource.isPlaying)
            tutorialAudioSource.Play();
        else if (!scene.name.StartsWith("Tutorial"))
            tutorialAudioSource.Stop();
    }
}

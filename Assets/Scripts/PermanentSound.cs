using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentSound : MonoBehaviour
{
    private AudioSource _tutorialAudioSource;
    private AudioSource _greenAudioSource;
    private AudioSource _desertAudioSource;
    
    private void Awake()
    {
        var audioSources = GetComponents<AudioSource>();
        _tutorialAudioSource = audioSources[0];
        _greenAudioSource = audioSources[1];
        _desertAudioSource = audioSources[2];
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Tutorial") && !_tutorialAudioSource.isPlaying)
            _tutorialAudioSource.Play();
        else if (!scene.name.StartsWith("Tutorial"))
            _tutorialAudioSource.Stop();
        
        if (scene.name.StartsWith("Green") && !_greenAudioSource.isPlaying)
            _greenAudioSource.Play();
        else if (!scene.name.StartsWith("Green"))
            _greenAudioSource.Stop();
            
        if (scene.name.StartsWith("Desert") && !_desertAudioSource.isPlaying)
            _desertAudioSource.Play();
        else if (!scene.name.StartsWith("Desert"))
            _desertAudioSource.Stop();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentSound : MonoBehaviour
{
    private AudioSource _tutorialAudioSource;
    private AudioSource _greenAudioSource;
    private AudioSource _desertAudioSource;
    private AudioSource _iceAudioSource;
    private AudioSource _waterAudioSource;
    private AudioSource _alienAudioSource;
    
    private void Awake()
    {
        var audioSources = GetComponents<AudioSource>();
        _tutorialAudioSource = audioSources[0];
        _greenAudioSource = audioSources[1];
        _desertAudioSource = audioSources[2];
        _iceAudioSource = audioSources[3];
        _waterAudioSource = audioSources[4];
        _alienAudioSource = audioSources[5];
        
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
            
        if (scene.name.StartsWith("Ice") && !_iceAudioSource.isPlaying)
            _iceAudioSource.Play();
        else if (!scene.name.StartsWith("Ice"))
            _iceAudioSource.Stop();
        
        if (scene.name.StartsWith("Water") && !_waterAudioSource.isPlaying)
            _waterAudioSource.Play();
        else if (!scene.name.StartsWith("Water"))
            _waterAudioSource.Stop();
            
        if (scene.name.StartsWith("Alien") && !_alienAudioSource.isPlaying)
            _alienAudioSource.Play();
        else if (!scene.name.StartsWith("Alien"))
            _alienAudioSource.Stop();
    }
}

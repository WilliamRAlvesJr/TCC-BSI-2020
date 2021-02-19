using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RageModeController : MonoBehaviour
{
    public static bool RageModeTrigger;
    public static bool IsOnRageMode;

    [SerializeField] private Material _outlineMaterial;
    [SerializeField] private Material _defaultSpriteMaterial;
    [SerializeField] private Light2D[] enemiesLights;
    
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _audioSource = GetComponents<AudioSource>()[1];
    }

    private void Update()
    {
        if (!_spriteRenderer.material.name.Equals("Sprite-Lit-Default (Instance)")) return;
        if (!RageModeTrigger) return;

        StartCoroutine(ActiveRageMode());
        RageModeTrigger = false;
    }

    private IEnumerator ActiveRageMode()
    {
        IsOnRageMode = true;
        
//        foreach (var enemyLight in enemiesLights)
//        {
//            enemyLight.color = Color.blue;
//        }
        
        _audioSource.Play();
        _spriteRenderer.material = _outlineMaterial;
        yield return new WaitForSeconds(4f);
        _spriteRenderer.material = _defaultSpriteMaterial;
        _audioSource.Stop();
        
//        foreach (var enemyLight in enemiesLights)
//        {
//            enemyLight.color = Color.red;
//        }
        
        IsOnRageMode = false;
    }

}

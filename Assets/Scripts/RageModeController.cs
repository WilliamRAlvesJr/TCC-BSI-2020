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
    
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
        
        foreach (var enemyLight in enemiesLights)
        {
            enemyLight.color = Color.blue;
        }
        
        _spriteRenderer.material = _outlineMaterial;
        yield return new WaitForSeconds(3f);
        _spriteRenderer.material = _defaultSpriteMaterial;
        
        foreach (var enemyLight in enemiesLights)
        {
            enemyLight.color = Color.red;
        }
        
        IsOnRageMode = false;
    }

}

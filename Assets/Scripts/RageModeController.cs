using System;
using UnityEngine;

public class RageModeController : MonoBehaviour
{
    [SerializeField] private Material _outlineMaterial;
    [SerializeField] private Material _defaultSpriteMaterial;

    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            _spriteRenderer.material = _outlineMaterial;
        if (Input.GetKeyDown(KeyCode.L))
            _spriteRenderer.material = _defaultSpriteMaterial;
    }
}

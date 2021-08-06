using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeinout : MonoBehaviour
{
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(PauseFade());
    }
    
    private IEnumerator PauseFade()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        
        yield return new WaitForSeconds(0.7f);
        _animator.SetTrigger("End");
    }
}

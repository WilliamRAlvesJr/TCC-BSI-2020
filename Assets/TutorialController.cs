using System.Collections;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject pause;
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
        GetComponent<AudioSource>().Play();
        pause.SetActive(true);
        
        yield return new WaitForSeconds(0.7f);
        _animator.SetTrigger("End");
        pause.SetActive(false);
    }
}

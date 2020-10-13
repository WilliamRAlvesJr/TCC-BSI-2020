using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Serialization;

public class LetterPickup : MonoBehaviour
{
    [SerializeField] private string letter;
    [SerializeField] private int letterPosition;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !other.name.Equals("PlayerCollider")) return;
        if (RageModeController.RageModeTrigger) return;

        ScoreScript.SetLetter(letter, letterPosition);
        
        RageModeController.RageModeTrigger = true;
        Destroy(gameObject);
    }
}

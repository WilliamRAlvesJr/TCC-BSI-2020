using UnityEngine;

public class LetterPickup : MonoBehaviour
{
    [SerializeField] private string letter;
    [SerializeField] private int letterPosition;
    public static bool LetterAlreadyInHand;
    private bool _thisLetterIsOnHand;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("EmployeeCollider"))
        {
            if (!other.GetComponentInParent<EmployeeExcite>().acceptableLetters.Contains(letter)) return;
            
            GameObject.Find("Player/PlayerRenderer/LetterInInventory").GetComponent<SpriteRenderer>().sprite = null;
            ScoreScript.SetLetter(letter, letterPosition);
            RageModeController.RageModeTrigger = true;
            LetterAlreadyInHand = false;
            Destroy(gameObject);
            
            foreach (var employee in GameObject.FindGameObjectsWithTag("EmployeeBase"))
            {
                employee.GetComponent<EmployeeExcite>().TriggerEmployee();
            }
            return;
        }
        
        if (LetterAlreadyInHand) return;
        if (!other.CompareTag("Player") || !other.name.Equals("PlayerCollider")) return;
        if (RageModeController.RageModeTrigger) return;

        GameObject.Find("Player/PlayerRenderer/LetterInInventory").GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        foreach (var employee in GameObject.FindGameObjectsWithTag("EmployeeBase"))
        {
            employee.GetComponent<EmployeeExcite>().TriggerEmployee();
        }
        DisableSpriteRenderer();
        
        LetterAlreadyInHand = true;
        _thisLetterIsOnHand = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_thisLetterIsOnHand && other.CompareTag("Player"))
            transform.position = other.transform.position;
    }

    private void DisableSpriteRenderer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }
    
}

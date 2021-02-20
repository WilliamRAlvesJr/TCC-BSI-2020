using UnityEngine;

public class LetterPickup : MonoBehaviour
{
    [SerializeField] private string letter;
    [SerializeField] private int letterPosition;
    [SerializeField] private bool isOrderer;
    public static bool LetterAlreadyInHand;
    private bool _thisLetterIsOnHand;
    private AudioSource _wrongLetterSound;
    private AudioSource _letterName;

    private void Awake()
    {
        var audioSources = GetComponents<AudioSource>();
        _wrongLetterSound = audioSources[0];
        _letterName = audioSources[1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("EmployeeCollider"))
        {
            if (!other.GetComponentInParent<EmployeeExcite>().acceptableLetters.Contains(letter))
            {
                _wrongLetterSound.Play();
                return;
            }
            other.GetComponentInParent<AudioSource>().Play();
            
            GameObject.Find("Player/PlayerRenderer/LetterInInventory").GetComponent<SpriteRenderer>().sprite = null;
            
            if (letterPosition >= 0) ScoreScript.SetLetter(letter, letterPosition);
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
        if (isOrderer)
        {
            if (ScoreScript.GetNextPosition() != letterPosition)
            {
                _wrongLetterSound.Play();
                return;
            }
        }
        if (RageModeController.RageModeTrigger) return;

        GameObject.Find("Player/PlayerRenderer/LetterInInventory").GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        foreach (var employee in GameObject.FindGameObjectsWithTag("EmployeeBase"))
        {
            employee.GetComponent<EmployeeExcite>().TriggerEmployee();
        }
        DisableSpriteRenderer();
        
        LetterAlreadyInHand = true;
        _thisLetterIsOnHand = true;
        _letterName.Play();
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

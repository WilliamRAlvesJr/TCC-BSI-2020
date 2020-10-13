using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int Score = 0;
    
    public static string Letters = "";
    
    [SerializeField] private string defaultLetters;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lettersText;

    [SerializeField] private Text scoreTextSceneManager;
    [SerializeField] private Text lettersTextSceneManager;
    
    [SerializeField] private GameObject player;
    
    private void Start()
    {
        Letters = defaultLetters;
    }
    
    private void Update()
    {
        scoreText.text = "" + Score;
        lettersText.text = Letters;
     
        scoreTextSceneManager.text = scoreText.text;
        lettersTextSceneManager.text = lettersText.text;

        if (!Letters.Contains("_"))
            Destroy(player);
    }

    public static void SetLetter(string letter, int position)
    {
        Letters = Letters.Remove(position, 1).Insert(position, letter);
    }
}

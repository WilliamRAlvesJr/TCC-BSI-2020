using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    
    public static int Score = 0;
    public static string Letters = "";
    
    [SerializeField] private string defaultLetters;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lettersText;
    
    [SerializeField] private Text scoreTextSceneManager;
    [SerializeField] private Text lettersTextSceneManager;
    
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject player;

    private void Start()
    {
        Letters = defaultLetters;
        nextButton.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = "" + Score;
        lettersText.text = Letters;
     
        scoreTextSceneManager.text = scoreText.text;
        lettersTextSceneManager.text = lettersText.text;

        if (Letters.Contains("_")) return;

        nextButton.SetActive(true);
        Destroy(player);

        SaveSystem.SaveLevelProgress(new LevelProgressData(
            Math.Max(levelNumber, SaveSystem.LoadLevelProgress().lastUnlockedLevel)
        ));
    }

    public static void SetLetter(string letter, int position)
    {
        Letters = Letters.Remove(position, 1).Insert(position, letter);
    }
}

﻿using System;
using System.Collections;
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
    private bool _finished;
    private AudioSource _endAudioSource;

    private void Start()
    {
        defaultLetters = defaultLetters.Replace("\\n", Environment.NewLine);
        Letters = defaultLetters;
        nextButton.SetActive(false);
        _endAudioSource = GetComponents<AudioSource>()[0];
    }

    private void Update()
    {
        if (_finished) return;
        
        scoreText.text = "" + Score;
        lettersText.text = Letters;
     
        scoreTextSceneManager.text = scoreText.text;
//        var auxLettersText = lettersText.text.Replace(Environment.NewLine, " ");
        lettersTextSceneManager.text = lettersText.text;

        if (Letters.Contains("_")) return;

        _endAudioSource.Play();
        
        nextButton.SetActive(true);
        Destroy(player);

        SaveSystem.SaveLevelProgress(new LevelProgressData(
            Math.Max(levelNumber + 1, SaveSystem.LoadLevelProgress().lastUnlockedLevel)
        ));

        StartCoroutine(SetFinished());
    }

    private IEnumerator SetFinished()
    {
        _finished = true;
        yield return new WaitForSeconds(1f);
        GetComponents<AudioSource>()[1].Play();
    }
    
    public static void SetLetter(string letter, int position)
    {
        Letters = Letters.Remove(position, letter.Length).Insert(position, letter);
    }

    public static int GetNextPosition()
    {
        return Letters.IndexOf("_", StringComparison.Ordinal);
    }
}

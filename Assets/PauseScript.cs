﻿using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0.1f;
    }
        
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    
}

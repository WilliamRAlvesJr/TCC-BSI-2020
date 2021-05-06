using System;
using UnityEngine;

public class TutorialReset : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;

    private float _timeDelay;

    private void Awake()
    {
        _timeDelay = Time.time + 2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Time.time > _timeDelay && Time.timeScale > 0.1f)
        {
            Instantiate(tutorial);
            _timeDelay = Time.time + 2f;
        }
    }
}

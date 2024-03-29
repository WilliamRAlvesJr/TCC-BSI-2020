﻿using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private void Start()
    {
        var slider = GetComponent<Slider>();
        slider.value = AudioListener.volume;
        slider.onValueChanged.AddListener(delegate { AudioListener.volume = slider.value; });
    }
}

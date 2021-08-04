using UnityEngine;
using UnityEngine.UI;

public class GameSpeedController : MonoBehaviour
{
    public static float GameSpeed = 0.75f;
    
    private void Awake()
    {
        var slider = GetComponent<Slider>();
        slider.value = GameSpeed;
        slider.onValueChanged.AddListener(delegate { GameSpeed = slider.value; });
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    private void OnEnable()
    {
        var buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < SaveSystem.LoadLevelProgress().lastUnlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
}

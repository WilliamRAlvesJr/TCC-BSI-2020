using System.Collections;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private Animator gui;
    [SerializeField] private Animator sceneManager;
    [SerializeField] private Animator[] stars = new Animator[3];

    [SerializeField] private int coinsPerStar;
    
    private static readonly int FadeOut = Animator.StringToHash("FadeOut");
    private static readonly int StarDown = Animator.StringToHash("StarDown");

    private void OnDestroy()
    {
        gui.SetTrigger(FadeOut);
        sceneManager.SetTrigger(FadeOut);

        var auxCoinsCounter = ScoreScript.Score;
        foreach (var star in stars)
        {
            auxCoinsCounter -= coinsPerStar;
            if (auxCoinsCounter < 0)
                break;
            
            star.SetTrigger(StarDown);
        }
    }
        
}

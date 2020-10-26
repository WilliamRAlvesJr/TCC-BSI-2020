using UnityEngine;
using UnityEngine.SceneManagement;

public static class NavigationManager
{
    public static void NavigateTo(string destination)
    {
        PlayerMovementController.NewVelocity = Vector2.zero;
        RageModeController.RageModeTrigger = false;
        RageModeController.IsOnRageMode = false;
        LetterPickup.LetterAlreadyInHand = false;
        ScoreScript.Score = 0;
        SceneManager.LoadScene(destination);
    }
}
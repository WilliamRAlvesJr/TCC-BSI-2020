using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerButtonHandler : MonoBehaviour
{
    private Animator _levelLoaderAnimator;
    private static readonly int End = Animator.StringToHash("End");

    [SerializeField] private string nextLevel;

    private void Start()
    {
        _levelLoaderAnimator = GameObject.Find("LevelLoader/CircleWipe").GetComponent<Animator>();
        
        var nextLevelButton = gameObject.transform.Find("NextLevelButton").GetComponent<Button>();
        nextLevelButton.onClick.AddListener(delegate() { StartCoroutine(GoToScene(nextLevel)); });
        
        var replayButton = gameObject.transform.Find("ReplayButton").GetComponent<Button>();
        replayButton.onClick.AddListener(delegate() { StartCoroutine(GoToScene(SceneManager.GetActiveScene().name)); });
        
        var homeButton = gameObject.transform.Find("HomeButton").GetComponent<Button>();
        homeButton.onClick.AddListener(delegate() { StartCoroutine(GoToScene("MainMenu")); });
    }

    private IEnumerator GoToScene(string nextScene)
    {
        _levelLoaderAnimator.SetTrigger(End);
        yield return new WaitForSeconds(1f);
        NavigationManager.NavigateTo(nextScene);
    }
    
}

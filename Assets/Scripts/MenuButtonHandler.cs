using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    private static readonly int LevelSelectorDown = Animator.StringToHash("LevelSelectorDown");
    private static readonly int GameOptionsLeft = Animator.StringToHash("GameOptionsLeft");

    private void Start()
    {
        var levelSelector = gameObject.transform.Find("LevelSelector");
        var gameOptions = gameObject.transform.Find("GameOptions");
        
        var playButton = gameObject.transform.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(delegate()
        {
            levelSelector.gameObject.SetActive(true);
            levelSelector.GetComponent<Animator>().SetTrigger(LevelSelectorDown);
        });
        
        var backPlayButton = gameObject.transform.Find("LevelSelector/BackButton").GetComponent<Button>();
        backPlayButton.onClick.AddListener(delegate() 
        {
            levelSelector.GetComponent<Animator>().SetTrigger(LevelSelectorDown);
            StartCoroutine(WaitForPosition(levelSelector.gameObject));
        });
        
        var configButton = gameObject.transform.Find("ConfigButton").GetComponent<Button>();
        configButton.onClick.AddListener(delegate() 
        {
            gameOptions.gameObject.SetActive(true);
            gameOptions.GetComponent<Animator>().SetTrigger(GameOptionsLeft);
        });
        
        var backConfigButton = gameObject.transform.Find("GameOptions/BackButton").GetComponent<Button>();
        backConfigButton.onClick.AddListener(delegate() 
        {
            gameOptions.GetComponent<Animator>().SetTrigger(GameOptionsLeft);
            StartCoroutine(WaitForPosition(gameOptions.gameObject));
        });
        
        var closeButton = gameObject.transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(Application.Quit);
    }

    private static IEnumerator WaitForPosition(GameObject disablePanel)
    {
        yield return new WaitForSeconds(0.5f);
        disablePanel.SetActive(false);
    }

}

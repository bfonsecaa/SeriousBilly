using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject options;
    public GameObject mainMenu;
    public GameObject health;
    public GameObject experience;

    public static bool isDead;
    public GameObject gameOver;
    public int endingLevel;

    void Start()
    {
        isDead = false;
        endingLevel = 1;
    }

    void Update()
    {
        GameOver();
    }

    public void OnClickPlay()
    {
        Application.LoadLevel("Main");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnClickMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void OnClickOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void OnClickFantastic()
    {
        QualitySettings.SetQualityLevel(5);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickBeautiful()
    {
        QualitySettings.SetQualityLevel(4);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickGood()
    {
        QualitySettings.SetQualityLevel(3);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickSimple()
    {
        QualitySettings.SetQualityLevel(2);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickFast()
    {
        QualitySettings.SetQualityLevel(1);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickFastest()
    {
        QualitySettings.SetQualityLevel(0);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void GameOver()
    {
        if (isDead == true)
        {
            health.SetActive(false);
            experience.SetActive(false);
            gameOver.SetActive(true);
            endingLevel = LevelText.level;
            YouAchieved.endingLevel = endingLevel;
        }

    }
}

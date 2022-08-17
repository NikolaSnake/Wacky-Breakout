using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    /// <summary>
    /// Go to desired menu
    /// </summary>
    /// <param name="menuName">Name of menu which will be loaded</param>
    public static void GoToMenu(MenuName menuName)
    {
        switch (menuName)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Help:
                GameObject mainMenuCanvas = GameObject.Find("MainMenuCanvas");
                mainMenuCanvas.SetActive(false);
                Object.Instantiate(Resources.Load("HelpMenuCanvas"));
                break;
            case MenuName.Difficulty:
                SceneManager.LoadScene("DifficultyMenu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenuCanvas"));
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Public methods

    /// <summary>
    /// Handler of OnClickEvent of exit button
    /// </summary>
    public void ExitGame()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        Application.Quit();
    }

    /// <summary>
    /// Handler of OnClickEvent of help button
    /// </summary>
    public void HelpButtonHandler()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// Handler of OnClickEvent of start button
    /// </summary>
    public void StartButtonHadler()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    #endregion
}

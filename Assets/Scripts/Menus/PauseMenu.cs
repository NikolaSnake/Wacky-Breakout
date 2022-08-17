using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    #region Public methods

    /// <summary>
    /// Handler of OnClickEvent of resume button
    /// </summary>
    public void ResumeButtonHandler()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Handler of OnClickEvent of exit button
    /// </summary>
    public void ExitButtonHadler()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    #endregion
}

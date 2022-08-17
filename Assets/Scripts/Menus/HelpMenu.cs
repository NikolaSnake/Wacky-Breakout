using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Handler of OnClickEvent of back button
    /// </summary>
    public void BackButtonHandler()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        MenuManager.GoToMenu(MenuName.Main);
    }
}

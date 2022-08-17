using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    // set score support
    [SerializeField]
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        // freeze game
        Time.timeScale = 0;
    }
    #region Public methods

    /// <summary>
    /// Handler of OnClickEvent of exit button
    /// </summary>
    public void ExitButtonHandler()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        // unfreeze game and go back to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);        
    }

    /// <summary>
    /// set score when game is over
    /// </summary>
    /// <param name="score">player's score when game is over</param>
    public void SetScore(int score)
    {
        scoreText.text = "Your score is " + score.ToString();
    }

    #endregion
}

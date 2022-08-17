using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    #region Unity methods

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddLastBallLostListener(GameOverLastBallLost);
        EventManager.AddBlockDestroyedListener(GameOverLastBlockDestroyed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    #endregion

    #region Private methods

    /// <summary>
    /// game over handler of last ball lost event
    /// </summary>
    void GameOverLastBallLost()
    {
        GameObject hud = GameObject.FindGameObjectWithTag("HUD");
        HUD hudScript = hud.GetComponent<HUD>();
        Object.Instantiate(Resources.Load("GameOverCanvas"));
        AudioManager.Play(AudioClipName.GameOverSound);
        GameObject gameOverCanvas = GameObject.FindGameObjectWithTag("GameOver");
        GameOverMenu gameOverScript = gameOverCanvas.GetComponent<GameOverMenu>();
        gameOverScript.SetScore(hudScript.Points); 
    }

    /// <summary>
    /// game over handler of last block destroyed event
    /// </summary>
    void GameOverLastBlockDestroyed()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 1)
        {
            GameObject hud = GameObject.FindGameObjectWithTag("HUD");
            HUD hudScript = hud.GetComponent<HUD>();
            Object.Instantiate(Resources.Load("GameOverCanvas"));
            AudioManager.Play(AudioClipName.GameOverSound);
            GameObject gameOverCanvas = GameObject.FindGameObjectWithTag("GameOver");
            GameOverMenu gameOverScript = gameOverCanvas.GetComponent<GameOverMenu>();
            gameOverScript.SetScore(hudScript.Points);
        }      
    }

    #endregion
}

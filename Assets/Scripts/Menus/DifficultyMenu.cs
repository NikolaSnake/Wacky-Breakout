using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyMenu : MonoBehaviour
{
    // game started event support
    GameStartedEvent gameStartedEvent = new GameStartedEvent();

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddGameStartedEventInvoker(this);
    }

    #region Public methods

    /// <summary>
    /// Add listener to game started event
    /// </summary>
    /// <param name="listener">listener of this event</param>
    public void GameStartedEventAddListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }

    /// <summary>
    /// Handler of OnClickEvent of easy button
    /// </summary>
    public void StartEasyGame()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        gameStartedEvent.Invoke(Difficulty.Easy);
    }

    /// <summary>
    /// Handler of OnClickEvent of medium button
    /// </summary>
    public void StartMediumGame()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        gameStartedEvent.Invoke(Difficulty.Medium);
    }

    /// <summary>
    /// Handler of OnClickEvent of hard button
    /// </summary>
    public void StartHardGame()
    {
        AudioManager.Play(AudioClipName.ButtonClickSound);
        gameStartedEvent.Invoke(Difficulty.Hard);
    }

    #endregion
}

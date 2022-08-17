using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides difficulty-specific utilities
/// </summary>
public static class DifficultyUtils
{
    #region Fields

    static Difficulty difficulty;

    #endregion

    #region Properties

    /// <summary>
    /// Property which return values of ball's impulse force depending on difficulty
    /// </summary>
    public static float BallImpulseForce
    {
        get
        {            
             switch (difficulty)
             {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBallImpulseForce;
                   // break;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBallImpulseForce;
                    //break;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBallImpulseForce;
                    //break;
                default: 
                    return 0;
             }
        }
    }

    /// <summary>
    /// Property which return values of ball's minimum spawn seconds depending on difficulty
    /// </summary>
    public static float MinSpawnSeconds
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
                // break;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinSpawnSeconds;
                //break;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinSpawnSeconds;
                //break;
                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// Property which return values of ball's maximum spawn seconds depending on difficulty
    /// </summary>
    public static float MaxSpawnSeconds
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
                // break;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxSpawnSeconds;
                //break;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxSpawnSeconds;
                //break;
                default:
                    return 0;
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddGameStartedEventListener(HandleGameStartedEvent);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Sets the difficulty and starts the game
    /// </summary>
    /// <param name="complexity">= difficulty</param>
    static void HandleGameStartedEvent(Difficulty complexity)
    {
        difficulty = complexity;
        SceneManager.LoadScene("Gameplay");
    }

    #endregion

}

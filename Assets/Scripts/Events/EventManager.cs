using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    #region Fields

    // ball died support
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners =
        new List<UnityAction>();

    // ball lost support
    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners =
        new List<UnityAction>();

    // points added support
    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners =
        new List<UnityAction<int>>();

    // freezer effect support
    static List<EffectBlock> freezerEffectActivatedInvokers = 
        new List<EffectBlock>();
    static List<UnityAction<float>> freezerEffectActivatedListeners =
        new List<UnityAction<float>>();

    // speedup effect support
    static List<EffectBlock> speedupEffectActivatedInvokers = new List<EffectBlock>();
    static List<UnityAction<float, float>> speedupEffectActivatedListeners =
        new List<UnityAction<float, float>>();

    // game started event support
    static List<DifficultyMenu> gameStartedInvokers = new List<DifficultyMenu>();
    static List<UnityAction<Difficulty>> gameStartedListeners =
        new List<UnityAction<Difficulty>>();

    // last ball lost event support
    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners = new List<UnityAction>();

    // last block destroyed event support
    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction> blockDestroyedListeners = new List<UnityAction>();

    #endregion

    #region Ball died support

    /// <summary>
    /// Adds the given script as a ball died invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBallDiedInvoker(Ball invoker)
    {
        // add invoker to list and add all listeners to invoker
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball died listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBallDiedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a ball died invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        // remove invoker from list
        ballDiedInvokers.Remove(invoker);
    }

    #endregion

    #region Ball lost support

    /// <summary>
    /// Adds the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBallLostInvoker(Ball invoker)
    {
        // add invoker to list and add all listeners to invoker
        ballLostInvokers.Add(invoker);
        foreach (UnityAction listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBallLostListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        ballLostListeners.Add(listener);
        foreach (Ball invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBallLostInvoker(Ball invoker)
    {
        // remove invoker from list
        ballLostInvokers.Remove(invoker);
    }

    #endregion

    #region Points added support

    /// <summary>
    /// Adds the given script as a points added invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPointsAddedInvoker(Block invoker)
    {
        // add invoker to list and add all listeners to invoker
        pointsAddedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a points added listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        // add listener to list and to all invokers
        pointsAddedListeners.Add(listener);
        foreach (Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a points added invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemovePointsAddedInvoker(Block invoker)
    {
        // remove invoker from list
        pointsAddedInvokers.Remove(invoker);
    }

    #endregion

    #region Freezer effect support

    /// <summary>
    /// Adds the given script as a freezer effect activated invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFreezerEffectActivatedInvoker(EffectBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        freezerEffectActivatedInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectActivatedListeners)
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a freezer effect activated listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFreezerEffectActivatedListener(UnityAction<float> listener)
    {
        // add listener to list and to all invokers
        freezerEffectActivatedListeners.Add(listener);
        foreach (EffectBlock invoker in freezerEffectActivatedInvokers)
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a freezer effect activated invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveFreezerEffectActivatedInvoker(EffectBlock invoker)
    {
        // remove invoker from list
        freezerEffectActivatedInvokers.Remove(invoker);
    }

    #endregion

    #region Speedup effect support

    /// <summary>
    /// Adds the given script as a speedup effect activated invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddSpeedupEffectActivatedInvoker(EffectBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        speedupEffectActivatedInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectActivatedListeners)
        {
            invoker.AddSpeedupEffectActivatedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a speedup effect activated listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        // add listener to list and to all invokers
        speedupEffectActivatedListeners.Add(listener);
        foreach (EffectBlock invoker in speedupEffectActivatedInvokers)
        {
            invoker.AddSpeedupEffectActivatedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a speedup effect activated invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveSpeedupEffectActivatedInvoker(EffectBlock invoker)
    {
        // remove invoker from list
        speedupEffectActivatedInvokers.Remove(invoker);
    }

    /// <summary>
    /// Removes the given method as a speedup effect activated listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void RemoveSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        // remove listener from list and from all invokers
        speedupEffectActivatedListeners.Remove(listener);
        foreach (EffectBlock invoker in speedupEffectActivatedInvokers)
        {
            invoker.RemoveSpeedupEffectActivatedListener(listener);
        }
    }

    #endregion

    #region Game stated event support

    /// <summary>
    /// Adds the given script as a game started event invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddGameStartedEventInvoker(DifficultyMenu invoker)
    {
        gameStartedInvokers.Add(invoker);
        foreach (UnityAction<Difficulty> listener in gameStartedListeners)
        {
            invoker.GameStartedEventAddListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a game started event listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddGameStartedEventListener(UnityAction<Difficulty> listener)
    {
        gameStartedListeners.Add(listener);
        foreach (DifficultyMenu invoker in gameStartedInvokers)
        {
            invoker.GameStartedEventAddListener(listener);
        }
    }
    #endregion

    #region Last ball lost event support

    /// <summary>
    /// Adds the given script as a last ball lost event invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.LastBallLostEventAddListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a last ball lost event listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.LastBallLostEventAddListener(listener);
        }
    }

    #endregion

    #region Block destroyed event support

    /// <summary>
    /// Adds the given script as a block destroyed event invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedEventListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a block destroyed event listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedListeners.Add(listener);
        foreach (Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedEventListener(listener);
        }
    }

    #endregion
}
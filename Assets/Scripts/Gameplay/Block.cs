using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A block
/// </summary>	
public class Block : MonoBehaviour
{
    #region Fields

    // scoring support
    int points;
    PointsAddedEvent pointsAddedEvent = new PointsAddedEvent();

    // block destroyed event support
    BlockDestroyedEvent blockDestroyedEvent = new BlockDestroyedEvent();

    #endregion

    #region Protected properties

    /// <summary>
    /// Sets the points the block is worth
    /// </summary>
    protected int Points
    {
        set { points = value; }
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    virtual protected void Start()
    {
        // add as invoker of events
        EventManager.AddPointsAddedInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            pointsAddedEvent.Invoke(points);
            AudioManager.Play(AudioClipName.StandardBlockSound);
            EventManager.RemovePointsAddedInvoker(this);
            Destroy(gameObject);
            blockDestroyedEvent.Invoke();
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Adds the given listener for the PointsAddedEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener for the BlockDestroyedEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddBlockDestroyedEventListener(UnityAction listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }

    #endregion
}

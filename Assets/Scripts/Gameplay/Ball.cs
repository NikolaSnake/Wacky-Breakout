using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>	
public class Ball : MonoBehaviour
{
    #region Fields

    // move delay timer
    Timer moveTimer;

    // death support
    Timer deathTimer;
    BallDiedEvent ballDiedEvent = new BallDiedEvent();

    // loss support
    BallLostEvent ballLostEvent = new BallLostEvent();

    // speedup effect support
    Rigidbody2D rb2d;
    Timer speedupTimer;
    float speedupFactor;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();
        moveTimer.AddTimerFinishedListener(HandleMoveTimerFinished);

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
        deathTimer.AddTimerFinishedListener(HandleDeathTimerFinished);

        // speedup effect support
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(HandleSpeedupTimerFinished);
        EventManager.AddSpeedupEffectActivatedListener(HandleSpeedupEffectActivatedEvent);
        rb2d = GetComponent<Rigidbody2D>();

        // add as invoker of events
        EventManager.AddBallDiedInvoker(this);
        EventManager.AddBallLostInvoker(this);
    }

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only spawn a new ball if below screen
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                // invoke event
                ballLostEvent.Invoke();
            }
            DestroyBall();
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    /// <summary>
    /// Adds the given listener for the BallDiedEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener for the BallLostEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // calculate force to apply
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));

        // adjust as necessary if speedup effect is active
        if (EffectUtils.SpeedupEffectActive)
        {
            StartSpeedupEffect(EffectUtils.SpeedupEffectSecondsLeft,
                EffectUtils.SpeedupFactor);
            force *= speedupFactor;
        }

        // get ball moving
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Destroys the ball
    /// </summary>
    void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        EventManager.RemoveSpeedupEffectActivatedListener(HandleSpeedupEffectActivatedEvent);
        Destroy(gameObject);
    }

    /// <summary>
    /// Stops the move timer and starts the ball moving
    /// </summary>
    void HandleMoveTimerFinished()
    {
        moveTimer.Stop();
        StartMoving();
    }

    /// <summary>
    /// Invokes event and destroys ball
    /// </summary>
    void HandleDeathTimerFinished()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }

    /// <summary>
    /// Handles the speedup effect activated event
    /// </summary>
    /// <param name="duration">duration of the speedup effect</param>
    /// <param name="speedupFactor">the speedup factor</param>
    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        // speed up ball and run or add time to timer
        if (!speedupTimer.Running)
        {
            StartSpeedupEffect(duration, speedupFactor);
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    /// <summary>
    /// Starts the speedup effect
    /// </summary>
    /// <param name="duration">duration of the speedup effect</param>
    /// <param name="speedupFactor">the speedup factor</param>
    void StartSpeedupEffect(float duration, float speedupFactor)
    {
        this.speedupFactor = speedupFactor;
        speedupTimer.Duration = duration;
        speedupTimer.Run();
    }

    /// <summary>
    /// Returns ball to normal speed
    /// </summary>
    void HandleSpeedupTimerFinished()
    {
        speedupTimer.Stop();
        rb2d.velocity *= 1 / speedupFactor;
    }

    #endregion
}

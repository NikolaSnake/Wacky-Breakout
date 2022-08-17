using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An effect block
/// </summary>	
public class EffectBlock : Block
{
    #region Fields

    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    // effect-specific values
    EffectName effect;
    float duration;
    FreezerEffectActivatedEvent freezerEffectActivatedEvent;
    float speedupFactor;
    SpeedupEffectActivatedEvent speedupEffectActivatedEvent;

    #endregion

    #region Properties

    /// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public EffectName Effect
    {
        set
        {
            effect = value;

            // set sprite and other
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == EffectName.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
                duration = ConfigurationUtils.FreezerSeconds;
                freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
                EventManager.AddFreezerEffectActivatedInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                speedupFactor = ConfigurationUtils.SpeedupFactor;
                duration = ConfigurationUtils.SpeedupSeconds;
                speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
                EventManager.AddSpeedupEffectActivatedInvoker(this);

            }
        }
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    override protected void Start()
    {
        base.Start();

        Points = ConfigurationUtils.EffectBlockPoints;
    }

    /// <summary>
    /// Invokes the effect event and destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    override protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if (effect == EffectName.Freezer)
            {
                freezerEffectActivatedEvent.Invoke(duration);
                AudioManager.Play(AudioClipName.FreezerBlockSound);
                EventManager.RemoveFreezerEffectActivatedInvoker(this);
            }
            else if (effect == EffectName.Speedup)
            {
                speedupEffectActivatedEvent.Invoke(duration, speedupFactor);
                AudioManager.Play(AudioClipName.SpeedBlockSound);
                EventManager.RemoveSpeedupEffectActivatedInvoker(this);
            }
            base.OnCollisionEnter2D(coll);
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Adds the given listener to the freezer effect activated event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddFreezerEffectActivatedListener(UnityAction<float> listener)
    {
        freezerEffectActivatedEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener to the speedup effect activated event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.AddListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the speedup effect activated event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.RemoveListener(listener);
    }

    #endregion
}

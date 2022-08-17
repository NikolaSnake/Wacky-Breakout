using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    #region Fields

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region Properties

    /// <summary>
    /// Is AudioManager initialized or not
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Initialize dictionary of audio clips
    /// </summary>
    /// <param name="source">sound's source with key of AudioClipName</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BonusBlockSound, Resources.Load<AudioClip>("BonusBlockSound"));
        audioClips.Add(AudioClipName.ButtonClickSound, Resources.Load<AudioClip>("ButtonClickSound"));
        audioClips.Add(AudioClipName.FreezerBlockSound, Resources.Load<AudioClip>("FreezerBlockSound"));
        audioClips.Add(AudioClipName.GameOverSound, Resources.Load<AudioClip>("GameOverSound"));
        audioClips.Add(AudioClipName.PaddleHitSound, Resources.Load<AudioClip>("PaddleHitSound"));
        audioClips.Add(AudioClipName.SpeedBlockSound, Resources.Load<AudioClip>("SpeedBlockSound"));
        audioClips.Add(AudioClipName.StandardBlockSound, Resources.Load<AudioClip>("StandardBlockSound"));
    }
    /// <summary>
    /// Play a sound
    /// </summary>
    /// <param name="name">name of sound</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    #endregion
}

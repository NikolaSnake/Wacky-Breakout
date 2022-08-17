using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball spawner
/// </summary>	
public class BallSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabBall;

    // spawn support
    Timer spawnTimer;
    float spawnRange;

    // collision-free support
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        // spawn and destroy ball to calculate
        // spawn location min and max
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        // initialize and start spawn timer
        spawnRange = ConfigurationUtils.MaxSpawnSeconds -
            ConfigurationUtils.MinSpawnSeconds;
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();
        spawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);

        // add listeners to event manager
        EventManager.AddBallDiedListener(SpawnBall);
        EventManager.AddBallLostListener(SpawnBall);

        // spawn first ball in game
        SpawnBall();
    }

    /// <summary>
	/// Update is called once per frame
	/// </summary>	
    void Update()
    {
        // try again if spawn still pending
        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Gets the spawn delay in seconds for the next ball spawn
    /// </summary>
    /// <returns>spawn delay</returns>
    float GetSpawnDelay()
    {
        return ConfigurationUtils.MinSpawnSeconds +
            Random.value * spawnRange;
    }

    /// <summary>
    /// Spawns a ball
    /// </summary>
    void SpawnBall()
    {
        // make sure we don't spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(prefabBall);
        }
        else
        {
            retrySpawn = true;
        }
    }

    /// <summary>
    /// Handles spawn timer finished event
    /// </summary>
    void HandleSpawnTimerFinished()
    {
        // don't stack with a spawn still pending
        retrySpawn = false;
        SpawnBall();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();
    }

    #endregion
}

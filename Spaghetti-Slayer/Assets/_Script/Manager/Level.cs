using System;
using UnityEngine;

/// <summary>
/// Encapsulates a level in the game. A level always has a special fork and an enemy to fight associated with it.
/// </summary>
public class Level : ILevel
{
    /// <summary>
    /// The enemy which should be fought in this level.
    /// </summary>
    [SerializeField]
    private readonly GameObject Enemy;
    /// <summary>
    /// The fork with which our hero fights the enemy.
    /// </summary>
    [SerializeField]
    private readonly GameObject Fork;

    public void Start(Func<GameObject, GameObject> instantiate, IAnimationManager animationManager)
    {
        GameObject instance = instantiate(Enemy);
        instance.GetComponent<Enemy>().OnStart += animationManager.PlayEnemyStartAnimation;
        instance.GetComponent<Enemy>().OnDeath += animationManager.PlayEnemyDeathAnimation;
        instance.GetComponent<Enemy>().OnWin += animationManager.PlayEnemyDeathAnimation;
    }
    public event Action LevelEnded;
}
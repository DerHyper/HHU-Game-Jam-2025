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

    public void Start(Func<GameObject, GameObject> instantiate)
    {
        GameObject instance = instantiate(Enemy);
    }

    public void EnemyStart(Animator animator)
    {
        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyStartAnimation(animator);
    }

    public void EnemyPointsChanged(float currentPoints, float maxPoints)
    {
        DependencyManager.TryGet<IUIManager>(out var uIManager);
        uIManager.UpdateEnemyPointsUI(currentPoints, maxPoints);
    }

    public void EnemyWin(Animator animator)
    {
        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyWinAnimation(animator);

        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.GameOver();
    }

    public void EnemyDied(Animator animator)
    {
        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyDeathAnimation(animator);

        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.LevelEnded();
    }
}
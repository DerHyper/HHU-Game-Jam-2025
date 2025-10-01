using System;
using UnityEngine;

/// <summary>
/// Encapsulates a level in the game. A level always has a special fork and an enemy to fight associated with it.
/// </summary>
public class LevelManager : MonoBehaviour, ILevel
{
    /// <summary>
    /// The enemy which should be fought in this level.
    /// </summary>
    [Header("Enemy")]
    [SerializeField] private readonly GameObject _enemy;
    [SerializeField] private readonly Transform _enemyTransform;

    /// <summary>
    /// The fork with which our hero fights the enemy.
    /// </summary>
    [Header("Fork")]
    [SerializeField] private readonly GameObject _fork;
    [SerializeField] private readonly Transform _forkTransform;

    public void Start()
    {
        GameObject enemyInstance = Instantiate(_enemy, _enemyTransform);
        GameObject forkInstance = Instantiate(_fork, _forkTransform);
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
        Destroy(_fork);
        Destroy(_enemy);

        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyWinAnimation(animator);

        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.GameOver();
    }

    public void EnemyDied(Animator animator)
    {
        Destroy(_fork);
        Destroy(_enemy);

        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyDeathAnimation(animator);

        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.LevelEnded();
    }
}
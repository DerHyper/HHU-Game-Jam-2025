using System;
using Unity.VisualScripting;
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
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _enemyTransform;

    /// <summary>
    /// The fork with which our hero fights the enemy.
    /// </summary>
    [Header("Fork")]
    [SerializeField] private GameObject _fork;
    [SerializeField] private Transform _forkTransform;
    private GameObject _enemyInstance;
    private GameObject _forkInstance;

    public void Init()
    {
        _enemyInstance = Instantiate(_enemy, _enemyTransform);
        _forkInstance = Instantiate(_fork, _forkTransform);
    }


    public void EnemyStart(Animator animator)
    {
        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyStartAnimation(animator);

        DeactivateEnemy();
    }


    public void OnLevelIntroEnded()
    {
        EnemyFight();
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
    }

    public void OnEnemyWinAnimationEnded()
    {
        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.GameOver();

        Destroy(_enemyInstance);
        Destroy(_forkInstance);
    }

    public void EnemyDied(Animator animator)
    {
        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyDeathAnimation(animator);
    }

    public void OnEnemyDiedAnimationEnded()
    {
        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.LevelEnded();

        Destroy(_enemyInstance);
        Destroy(_forkInstance);
    }

    private void DeactivateEnemy()
    {
        _enemyInstance.GetComponent<Enemy>().Intro();
    }

    private void EnemyFight()
    {
        if (_enemyInstance.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Fight();
        }

        DependencyManager.TryGet<IAnimationManager>(out var animationManager);
        animationManager.PlayEnemyFightAnimation(_enemyInstance.GetComponent<Enemy>().Animator);
    }
}
using System;
using UnityEngine;

/// <summary>
/// Abstract level which is a phase in which our protagonist can fight an enemy.
/// </summary>
public interface ILevel : IEnemyLevelEvents, ILevelAnimationsCallbacks
{
    /// <summary>
    /// Starts the current level.
    /// </summary>
    void Init();
}

/// <summary>
/// Level events which are triggered by the enemy MonoBehaviour.
/// </summary>
public interface IEnemyLevelEvents
{
    /// <summary>
    /// Should be called when the enemies points changed.
    /// </summary>
    /// <param name="currentPoints">The new points of the enemy.</param>
    /// <param name="maxPoints">The max points of the enemy which should not change.</param>
    void EnemyPointsChanged(float currentPoints, float maxPoints);
    /// <summary>
    /// Should be called when the enemy wins and the player dies.
    /// </summary>
    /// <param name="enemyAnimator">The enemy animator.</param>
    void EnemyWin(Animator enemyAnimator);
    /// <summary>
    /// Should be called when the enemy starts.
    /// </summary>
    /// <param name="enemyAnimator">The enemy animator.</param>
    void EnemyStart(Animator enemyAnimator);
    /// <summary>
    /// Should be called when the enemy dies which leads to the player winning this level.
    /// </summary>
    /// <param name="enemyAnimator">The enemy animator.</param>
    void EnemyDied(Animator animator);
    /// <summary>
    /// Moves the fork to hit the enemy.
    /// </summary>
    public void MoveFork();

}

public interface ILevelAnimationsCallbacks
{
    void OnLevelIntroEnded();
    void OnEnemyWinAnimationEnded();
    void OnEnemyDiedAnimationEnded();
}
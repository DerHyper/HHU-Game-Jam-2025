using System;
using UnityEngine;

/// <summary>
/// Each scene currently has three stages:
/// The Intro stage, in which an enemy is introduced.
/// The Fight stage, in which the enemy is fought.
/// The Outro stage, in which an outro of the enemy is played.
/// </summary>
public interface IAnimationManager
{
    /// <summary>
    /// Starts the intro animation of the game.
    /// </summary>
    void StartIntroAnimation();

    /// <summary>
    /// Fires when the intro animation ended.
    /// </summary>
    event Action IntroEnded;


    /// <summary>
    /// Starts the Outro animation of the current scene.
    /// </summary>
    void StartOutroAnimation();

    /// <summary>
    /// Plays the death animation for the given enemy.
    /// </summary>
    /// <param name="animator"></param>
    void PlayEnemyDeathAnimation(Animator animator);

    /// <summary>
    /// Plays the start animation for the given enemy.
    /// </summary>
    /// <param name="animator"></param>
    void PlayEnemyStartAnimation(Animator animator);

    /// <summary>
    /// Plays the win animation for the given enemy.
    /// </summary>
    /// <param name="animator"></param>
    void PlayEnemyWinAnimation(Animator animator);

    /// <summary>
    /// Plays the death animation for the given enemy.
    /// </summary>
    /// <param name="animator"></param>
    void PlayEnemyDeathAnimation(Animator animator);

    /// <summary>
    /// Plays the start animation for the given enemy.
    /// </summary>
    /// <param name="animator"></param>
    void PlayEnemyStartAnimation(Animator animator);

    /// <summary>
    /// Plays the win animation for the given enemy.
    /// </summary>
    /// <param name="animator"></param>
    void PlayEnemyWinAnimation(Animator animator);

    /// <summary>
    /// Fires when the outro animation 
    /// </summary>
    event Action OutroEnded;
}



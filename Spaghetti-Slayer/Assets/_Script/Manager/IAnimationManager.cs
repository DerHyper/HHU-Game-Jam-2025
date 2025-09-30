using System;

/// <summary>
/// Each scene currently has three stages:
/// The Intor stage, in which an enemy is introduced.
/// The Fight stage, in which the enemy is fought.
/// The Outro stage, in which an outro of the enemy is played.
/// </summary>
public interface IAnimationManager
{
    /// <summary>
    /// Starts the intor animation of the currenty scene.
    /// </summary>
    void StartIntroAnimation();

    /// <summary>
    /// Fiers when the inro animation ended.
    /// </summary>
    event Action IntorEnded;


    /// <summary>
    /// Starts the Outro animation of the current scene.
    /// </summary>
    void StartOutroAnimation();

    /// <summary>
    /// Fiers when the outro animation 
    /// </summary>
    event Action OutroEnded;
}



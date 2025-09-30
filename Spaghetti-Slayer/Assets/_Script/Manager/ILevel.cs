using System;

/// <summary>
/// Abstract level which is a phase in which our protagonist can fight an enemy.
/// </summary>
public interface ILevel
{
    /// <summary>
    /// Starts the current level.
    /// </summary>
    void Start();

    /// <summary>
    /// Fiers when the level ends, which should trigger the start of the next level.
    /// </summary>
    event Action LevelEnded;
}
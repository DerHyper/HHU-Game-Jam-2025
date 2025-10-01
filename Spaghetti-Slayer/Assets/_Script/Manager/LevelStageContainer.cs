using UnityEngine;

/// <summary>
/// Manages all levels of the game.
/// </summary>
public class LevelStageContainer
{
    private ushort _currentLevel = 0;

    /// <summary>
    /// The levels playable in the game.
    /// </summary>
    [SerializeField]
    private readonly ILevel[] _level;

    /// <summary>
    /// Checks wether there is still a level to play.
    /// </summary>
    /// <returns>True if there is still a level to play false otherwise.</returns>
    public bool HasNextLevel() => _currentLevel < _level.Length;
    /// <summary>
    /// Goes to the next level and returns that level.
    /// </summary>
    /// <returns>The now current level.</returns>
    public ILevel NextLevel() => _level[_currentLevel++];
    /// <summary>
    /// Returns the current level.
    /// </summary>
    /// <returns>The current level.</returns>
    public ILevel CurrentLevel() => _level[_currentLevel];
}

public enum GameState
{
    /// <summary>
    /// Indicates that the game was not started yet. 
    /// </summary>
    UnStarted,
    /// <summary>
    /// The game is currently in the intro state in which an introductory scene is played.
    /// </summary>
    Intro,
    /// <summary>
    /// The game is currently playing any level.
    /// </summary>
    Level,
    /// <summary>
    /// The game is finished and the Outro is played.
    /// </summary>
    Outro,
}
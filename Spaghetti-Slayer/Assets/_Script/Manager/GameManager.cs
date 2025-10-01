using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager : IManager
{
   void GameOver();
   void LevelEnded();
}

public interface ILevelManager : IManager
{
   ILevel CurrentLevel { get; }
}

public class GameManager : MonoBehaviour, IGameManager
{
   #region Managers
   private IAnimationManager _animationManager => DependencyManager.TryGet<IAnimationManager>(out var manager) ? manager : null;
   private IUIManager UiManager => DependencyManager.TryGet<IUIManager>(out var manager) ? manager : null;
   /// <summary>
   /// The levels playable in the game.
   /// </summary>
   [SerializeField] private List<GameObject> _level;
   #endregion

   /// <summary>
   /// Current state of the game.
   /// </summary>
   public GameState State { get; private set; } = GameState.UnStarted;


   #region Singleton
   public static GameManager Instance;

   private void Awake()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(this);
      }
      else
      {
         Instance = this;
      }
   }
   #endregion


   /// <summary>
   /// Is called on initialization.
   /// Starts the Intro and registers a callback to start a level, for when the intro is finished.
   /// </summary>
   public void Start()
   {
      State = GameState.Intro;

      _animationManager.IntroEnded += NextLevel;
      // Intro seq in start method
      // Animation manager start anmiation
      _animationManager.StartIntroAnimation();
   }

   /// <summary>
   /// The currently played level.
   /// </summary>
   public ILevel CurrentLevel => LevelCurrentLevel();

   /// <summary>
   /// Starts the next level if there is still a level left, otherwise the outro is started which ends the game.
   /// </summary>
   private void NextLevel()
   {
      State = GameState.Level;

      if (!LevelHasNextLevel())
      {
         Outro();
         return;
      }

      ILevel level = LevelNextLevel();
      level.Start();
   }

   public void LevelEnded() => NextLevel();

   public void GameOver() => throw new NotImplementedException();

   /// <summary>
   /// Starts the end of the entire game.
   /// </summary>
   private void Outro()
   {
      State = GameState.Outro;

      // Manager needs to know when it is over and got to the next state.
      // GameState that can be accessed from outside
      _animationManager.StartOutroAnimation();
   }


   /// <summary>
   /// Manages all levels of the game.
   /// </summary>
   #region LevelContainer 
   private static ushort _currentLevel = 0;

   /// <summary>
   /// Checks wether there is still a level to play.
   /// </summary>
   /// <returns>True if there is still a level to play false otherwise.</returns>
   public bool LevelHasNextLevel() => _currentLevel < _level.Count;
   /// <summary>
   /// Goes to the next level and returns that level.
   /// </summary>
   /// <returns>The now current level.</returns>
   public ILevel LevelNextLevel() => _level[_currentLevel++].GetComponent<ILevel>();
   /// <summary>
   /// Returns the current level.
   /// </summary>
   /// <returns>The current level.</returns>
   public ILevel LevelCurrentLevel() => _level[_currentLevel].GetComponent<ILevel>();
   #endregion
}


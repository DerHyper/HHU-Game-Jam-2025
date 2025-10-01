using System;
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
   private readonly IAnimationManager _animationManager;
   private readonly IUIManager _uiManager;
   private readonly LevelStageContainer _levelManager;
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
   public ILevel CurrentLevel => _levelManager.CurrentLevel();

   /// <summary>
   /// Starts the next level if there is still a level left, otherwise the outro is started which ends the game.
   /// </summary>
   private void NextLevel()
   {
      State = GameState.Level;

      if (!_levelManager.HasNextLevel())
      {
         Outro();
         return;
      }

      ILevel level = _levelManager.NextLevel();
      level.Start(Instantiate);
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
}


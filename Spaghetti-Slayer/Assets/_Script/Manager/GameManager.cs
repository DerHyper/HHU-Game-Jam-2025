using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IGameManager : IManager
{
   void GameOver();
   void LevelEnded();
   void IntroEnded(object _);
   void OutroEnded();
   void GameOverEnded();
}

public interface ILevelManager : IManager
{
   ILevel CurrentLevel { get; }
}

public class GameManager : MonoBehaviour, IGameManager, ILevelManager
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
   [SerializeField] private AudioClip _introMusic;
   [SerializeField] private float _introMusicVolume = 0.5f;
   [SerializeField] private AudioClip _outroMusic;
   [SerializeField] private float _outroMusicVolume = 0.5f;

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
   void Start()
   {
      State = GameState.Intro;
      Intro();
   }

   /// <summary>
   /// Should subscribe to the event when the intro ended.
   /// https://docs.unity3d.com/6000.0/Documentation/Manual/script-AnimationWindowEvent.html
   /// </summary>
   /// <param name="_"></param>
   public void IntroEnded(object _) => NextLevel();
   public void OutroEnded()
   {
      DependencyManager.TryGet<IUIManager>(out var uiManager);
      uiManager.OpenCredits();
   }

   public void GameOverEnded()
   {
      // Restart the scene
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
      Debug.Log("Next level starting");
      State = GameState.Level;

      if (!LevelHasNextLevel())
      {
         Outro();
         return;
      }

      ILevel level = LevelNextLevel();
      level.Init();
   }

   public void LevelEnded() => NextLevel();

   public void GameOver()
   {
      _animationManager.StartOutroAnimation();
      Debug.Log("Game is over but not yet implemented");
   }

   /// <summary>
   /// Starts the intro of the game.
   /// </summary>
   private void Intro()
   {
      // Animation manager start anmiation
      _animationManager.StartIntroAnimation();
      AudioManager.Instance.PlayMusic(_introMusic, _introMusicVolume);

   }

   /// <summary>
   /// Starts the end of the entire game.
   /// </summary>
   private void Outro()
   {
      Debug.Log("Victory!");
      State = GameState.Outro;

      // Manager needs to know when it is over and got to the next state.
      // GameState that can be accessed from outside
      _animationManager.StartOutroAnimation();
      AudioManager.Instance.PlayMusic(_outroMusic, _outroMusicVolume);
   }


   /// <summary>
   /// Manages all levels of the game.
   /// </summary>
   #region LevelContainer 
   private short _currentLevel = -1;

   /// <summary>
   /// Checks wether there is still a level to play.
   /// </summary>
   /// <returns>True if there is still a level to play false otherwise.</returns>
   public bool LevelHasNextLevel() => _currentLevel < _level.Count - 1;
   /// <summary>
   /// Goes to the next level and returns that level.
   /// </summary>
   /// <returns>The now current level.</returns>
   public ILevel LevelNextLevel() => _level[++_currentLevel].GetComponent<ILevel>();
   /// <summary>
   /// Returns the current level.
   /// </summary>
   /// <returns>The current level.</returns>
   public ILevel LevelCurrentLevel() => _level[_currentLevel].GetComponent<ILevel>();
   #endregion
}


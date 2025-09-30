
using System;
using System.Collections.Generic;
using UnityEngine;

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

   event Action IntorEnded;


   /// <summary>
   /// Starts the Outro animation of the current scene.
   /// </summary>
   void StartOutroAnimation();
   event Action OutroEnded;
}

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private List<GameObject> _enemies;

   [SerializeField]
   private List<GameObject> _forks;

   private readonly IAnimationManager _animationManager;
   private readonly IEnemyManager _enemyManager;


   public void Start()
   {
      _animationManager.IntorEnded += Fight;
      // Intro seq in start method
      // Animation manager start anmiation
      _animationManager.StartIntroAnimation();
   }


   private void Fight()
   {
      // spawn first enemy
      // enemy spawinind manager for that
      // enemies deceid their own state (state as enum)
      _enemyManager.SpawnEnemy(EnemyDied);
   }

   private void EnemyDied()
   {
      // Manager needs to know when it is over and got to the next state.
      // GameState that can be accessed from outside

      _animationManager.StartOutroAnimation();
   }
}
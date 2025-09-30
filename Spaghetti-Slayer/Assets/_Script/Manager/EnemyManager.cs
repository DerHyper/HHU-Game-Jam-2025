using System;
using UnityEngine;

public interface IKillable
{
    /// <summary>
    /// An event that is triggered when the implementing object dies.
    /// </summary>
    event Action OnDeath;
}

public interface IEnemyManager
{
    /// <summary>
    /// Spawns an enemy into the scene.
    /// </summary>
    /// <param name="enemyDied">A callback function that should be called when the enemy dies.</param>
    void SpawnEnemy(Action enemyDied);
}

public class EnemyManager : MonoBehaviour, IEnemyManager 
{
    [SerializeField] private GameObject _enemyPrefab;

    public void SpawnEnemy(Action enemyDied)
    {
        GameObject enemyObj = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
        IKillable enemy = enemyObj.GetComponent<IKillable>();

        enemy.OnDeath += enemyDied;
    }
}
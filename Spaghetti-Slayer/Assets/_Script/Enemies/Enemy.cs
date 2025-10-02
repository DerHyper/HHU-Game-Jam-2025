using System;
using UnityEngine;

/// <summary>
/// Class representing an enemy.
/// If _maxPoints is reached, the enemy wins and the Player dies.
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private float _maxPoints;
    [SerializeField] private AudioClip _dmgSound;
    [SerializeField] private AudioClip _dieSound;
    [SerializeField] private AudioClip _music;
    [SerializeField] private float _dieSoundVolume = 0.5f;
    [SerializeField] private float _dmgSoundVolume = 0.5f;
    [SerializeField] private float _musicVolume = 0.5f;
    private float _currentPoints;
    [SerializeField] private float _pointsPerSecond = 1f;
    private const float CLICK_DAMAGE = 1f;
    private bool _isDead = false;
    private bool _isActive = false;

    public Animator Animator => _enemyAnimator;

    private void Start()
    {
        _currentPoints = _maxPoints / 2f;
        CurrentLevel.EnemyStart(_enemyAnimator);
        AudioManager.Instance.PlayMusic(_music, _musicVolume);
    }

    private void Update()
    {
        if (!_isActive || _isDead) return;
        AddPoints(_pointsPerSecond * Time.deltaTime);
        if (_currentPoints >= _maxPoints)
        {
            _isDead = true;
            Win();
        }
    }

    /// <summary>
    /// Triggers the win event, which leads to the player's death.
    /// </summary>
    private void Win()
    {
        CurrentLevel.EnemyWin(_enemyAnimator);
    }

    /// <summary>
    /// Reduces the enemy's points by a fixed amount.
    /// </summary>
    public void TakeDamage()
    {
        if (!_isActive) { return; }

        AudioManager.Instance.PlayOncePitchedRandom(_dmgSound, _dmgSoundVolume);
        AddPoints(-CLICK_DAMAGE);
        if (_currentPoints <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Triggers the death event, which leads to the enemy's death.
    /// </summary>
    private void Die()
    {
        CurrentLevel.EnemyDied(_enemyAnimator);
        AudioManager.Instance.PlayOnce(_dieSound, _dieSoundVolume);
        _isDead = true;
    }

    /// <summary>
    /// Increases the enemy's points by the specified amount.
    /// </summary>
    /// <param name="points">Amount of points that will be added to the enemy</param>
    public void AddPoints(float points)
    {
        _currentPoints += points;
        _currentPoints = Mathf.Clamp(_currentPoints, 0, _maxPoints);
        CurrentLevel.EnemyPointsChanged(_currentPoints, _maxPoints);
    }

    /// <summary>
    /// Returns the current health percentage of the enemy.
    /// </summary>
    /// <returns>Float value between 0 and 1</returns>
    public float GetHealthPercentage()
    {
        return _currentPoints / _maxPoints;
    }

    public void Fight()
    {
        _isActive = true;
        gameObject.GetComponentInChildren<Hitpoint>(true).Activate();
    }

    public void Inactive()
    {
        _isActive = false;
        gameObject.GetComponentInChildren<Hitpoint>(true).Deactivate();
    }

    private ILevel CurrentLevel => DependencyManager.TryGet<ILevelManager>(out var gameManager) ? gameManager.CurrentLevel : null;
}

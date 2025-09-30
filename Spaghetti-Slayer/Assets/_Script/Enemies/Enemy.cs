using UnityEngine;

/// <summary>
/// Class representing an enemy.
/// If _maxPoints is reached, the enemy wins and the Player dies.
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxPoints;
    [SerializeField] private float _currentPoints;
    [SerializeField] private float _pointsPerSecond = 1f;
    private const float CLICK_DAMAGE = 1f;

    private void Start()
    {
        _currentPoints = _maxPoints / 2f;
    }

    private void Update()
    {
        AddPoints(_pointsPerSecond * Time.deltaTime);

        if (_currentPoints <= 0)
        {
            Die();
        }
        else if (_currentPoints >= _maxPoints)
        {
            Win();
        }
    }

    public void TakeDamage()
    {
        AddPoints(-CLICK_DAMAGE);
    }

    public void AddPoints(float points)
    {
        _currentPoints += points;
        _currentPoints = Mathf.Clamp(_currentPoints, 0, _maxPoints);
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Win()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns the current health percentage of the enemy.
    /// </summary>
    /// <returns>Float value between 0 and 1</returns>
    public float GetHealthPercentage()
    {
        return _currentHealth / _maxHealth;
    }
}

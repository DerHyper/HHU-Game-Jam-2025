using UnityEngine;

public interface IUIManager
{
    /// <summary>
    /// Updates the enemy points UI.
    /// </summary>
    public void UpdateEnemyPointsUI(float currentPoints, float maxPoints);
}

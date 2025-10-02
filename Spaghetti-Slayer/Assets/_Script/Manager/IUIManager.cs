public interface IUIManager : IManager
{
    /// <summary>
    /// Updates the enemy points UI.
    /// </summary>
    public void UpdateEnemyPointsUI(float currentPoints, float maxPoints);

    /// <summary>
    /// Opens the credits menu.
    /// </summary>
    public void OpenCredits();
}

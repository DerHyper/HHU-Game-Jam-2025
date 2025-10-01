using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager, IManager
{
    [SerializeField] private Transform _enemyPointsBarMask;

    public void UpdateEnemyPointsUI(float currentPoints, float maxPoints)
    {
        _enemyPointsBarMask.localScale = new Vector3(currentPoints / maxPoints, 1, 1);
    }
}
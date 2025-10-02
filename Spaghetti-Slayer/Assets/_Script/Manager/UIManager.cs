using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private Transform _enemyPointsBarMask;
    [SerializeField] private GameObject _creditsMenu;

    public void OpenCredits()
    {
        if (!_creditsMenu.activeSelf)
        {
            _creditsMenu.SetActive(true);
        }
    }

    public void UpdateEnemyPointsUI(float currentPoints, float maxPoints)
    {
        _enemyPointsBarMask.localScale = new Vector3(Mathf.Clamp01(currentPoints / maxPoints), 1, 1);
    }
}
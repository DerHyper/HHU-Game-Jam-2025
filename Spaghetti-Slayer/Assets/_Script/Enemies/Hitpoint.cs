using UnityEngine;

public class Hitpoint : MonoBehaviour
{
    private bool _isActive = false;
    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!_isActive) { return; }

        Debug.Log("Hit");
        gameObject.transform.parent.GetComponent<Enemy>().TakeDamage();
        DependencyManager.TryGet<ILevelManager>(out var levelManager);
        levelManager.CurrentLevel.MoveFork();
    }
}

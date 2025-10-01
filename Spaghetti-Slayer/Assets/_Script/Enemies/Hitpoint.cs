using Unity.VisualScripting;
using UnityEngine;

public class Hitpoint : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Hit");
        gameObject.transform.parent.GetComponent<Enemy>().TakeDamage();
        DependencyManager.TryGet<ILevelManager>(out var levelManager);
        levelManager.CurrentLevel.MoveFork();
    }
}

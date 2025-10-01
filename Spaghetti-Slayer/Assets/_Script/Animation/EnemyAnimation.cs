using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public void OnLevelIntroEnded()
    {
        DependencyManager.TryGet<ILevelManager>(out var levelManager);
        levelManager.CurrentLevel.OnLevelIntroEnded();
    }


    public void OnEnemyWinAnimationEnded()
    {
        DependencyManager.TryGet<ILevelManager>(out var levelManager);
        levelManager.CurrentLevel.OnEnemyWinAnimationEnded();
    }


    public void OnEnemyDiedAnimationEnded()
    {
        DependencyManager.TryGet<ILevelManager>(out var levelManager);
        levelManager.CurrentLevel.OnEnemyDiedAnimationEnded();
    }
}
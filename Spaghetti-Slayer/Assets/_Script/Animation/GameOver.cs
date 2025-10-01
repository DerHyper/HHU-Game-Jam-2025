using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GameOverEnded()
    {
        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.GameOverEnded();
    }
}
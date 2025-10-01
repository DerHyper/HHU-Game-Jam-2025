using UnityEngine;

public class Outro : MonoBehaviour
{
    public void OutroEnded()
    {
        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.OutroEnded();
    }
}
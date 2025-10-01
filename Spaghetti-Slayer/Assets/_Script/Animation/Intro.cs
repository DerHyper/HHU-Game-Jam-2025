using UnityEngine;

public class Intro : MonoBehaviour
{
    public void IntroEnded()
    {
        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.IntroEnded(null);
    }
}

using System;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public void IntroFinished()
    {
        DependencyManager.TryGet<IGameManager>(out var gameManager);
        gameManager.IntroEnded(null);
        gameObject.SetActive(false);
    }

    public void Test(string s)
    {
        Debug.Log(s);
    }
}


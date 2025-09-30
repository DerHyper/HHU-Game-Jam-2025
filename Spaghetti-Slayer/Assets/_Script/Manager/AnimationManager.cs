using System;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationManager : IAnimationManager
{
    public event Action OutroEnded;
    public event Action IntroEnded;

    public void StartIntroAnimation()
    {
        throw new NotImplementedException();
    }

    public void StartOutroAnimation()
    {
        throw new NotImplementedException();
    }

    public void PlayEnemyDeathAnimation(Animator animator)
    {
        animator.SetTrigger("Die");
    }

    public void PlayEnemyWinAnimation(Animator animator)
    {
        animator.SetTrigger("Win");
    }

    public void PlayEnemyStartAnimation(Animator animator)
    {
        animator.SetTrigger("Start");
    }
}
using System;
using UnityEngine;

public class AnimationManager : MonoBehaviour, IAnimationManager
{

    [SerializeField] private Animator _introAnimator;
    [SerializeField] private Animator _outroAnimator;


    public void StartIntroAnimation()
    {
        //_introAnimator.SetTrigger("intro");
    }

    public void StartOutroAnimation()
    {
        _outroAnimator.SetTrigger("outro");
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

    public void HitFork(Animator animator)
    {
        animator.SetTrigger("Hit");
    }
}
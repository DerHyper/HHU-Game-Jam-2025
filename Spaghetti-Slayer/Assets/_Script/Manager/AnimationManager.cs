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

    public void PlayEnemyFightAnimation(Animator animator)
    {
        animator.SetTrigger("fight");
    }

    public void PlayEnemyDeathAnimation(Animator animator)
    {
        animator.SetTrigger("died");
    }

    public void PlayEnemyWinAnimation(Animator animator)
    {
        animator.SetTrigger("win");
    }

    public void PlayEnemyStartAnimation(Animator animator)
    {
        animator.SetTrigger("intro");
    }
}
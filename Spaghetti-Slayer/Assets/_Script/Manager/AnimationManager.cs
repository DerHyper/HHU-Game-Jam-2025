using System;
using UnityEngine;

public class AnimationManager : MonoBehaviour, IAnimationManager
{

    [SerializeField] private Animator _introAnimator;
    [SerializeField] private Animator _outroAnimator;
    [SerializeField] private Animator _gameOverAnimator;


    public void StartIntroAnimation()
    {
        //_introAnimator.SetTrigger("intro");
    }

    public void StartOutroAnimation()
    {
        _outroAnimator.SetTrigger("outro");
    }

    public void StartGameOverAnimation()
    {
        _gameOverAnimator.SetTrigger("gameover");
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

    public void HitFork(Animator animator)
    {
        animator.SetTrigger("Hit");
    }
}
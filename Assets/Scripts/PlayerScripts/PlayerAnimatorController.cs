using System;
using System.Collections;
using System.Collections.Generic;
using CollectRace;
using UnityEngine;

public class PlayerAnimatorController : MonoSingleton<PlayerAnimatorController>
{
    [SerializeField] public Animator _animator;
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Win = Animator.StringToHash("Win");
    private static readonly int Lose = Animator.StringToHash("Lose");
    public bool isWin;

    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
    }
    public void SetRunBool()
    {
        _animator.SetBool("Run", true);
    }
    public void SetIdleBool()
    {
        _animator.SetBool("Run", false);
    }
    public void SetTriggerFinish()
    {
        if (WinController.Instance.isWin == true)
        {
            SetWinTrigger();
        }
        if (WinController.Instance.isLose == true)
        {
            SetLoseTrigger();
        }
    }
    private void SetWinTrigger()
    {
        _animator.SetTrigger(Win);
    }
    private void SetLoseTrigger()
    {
        _animator.SetTrigger(Lose);
    }
}

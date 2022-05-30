using System;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;
using CollectRace;

public class PlayerController : MonoSingleton<PlayerController>
{
    [Header("-CHARACTER MOVE-")]
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if (GameManager.instance.playerState == GameManager.PlayerState.Finish)
        {
            PlayerAnimatorController.Instance.SetTriggerFinish();
        }
        if (GameManager.instance.playerState == GameManager.PlayerState.Playing)
            {
                Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
                movementDirection.Normalize();
                transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
                if (movementDirection != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    transform.localRotation = Quaternion.RotateTowards(transform.localRotation, toRotation, turnSpeed * Time.deltaTime);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, transform.localRotation.y, 0);
                }
            }
        if (horizontalInput == 0 && verticalInput == 0)
        {
            PlayerAnimatorController.Instance.SetIdleBool();
        }
        else
        {
            PlayerAnimatorController.Instance.SetRunBool();
        }
    }
}
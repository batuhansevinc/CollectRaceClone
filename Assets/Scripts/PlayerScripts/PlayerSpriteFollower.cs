using System;
using UnityEngine;
using DG.Tweening;

namespace DefaultNamespace
{
    public class PlayerSpriteFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offSet;
        [SerializeField] private bool lookAt;

        private void Update()
        {
            FollowPlayer();
        }

        void FollowPlayer()
        {
            if (lookAt)
            {
                transform.LookAt(target);
            }
            transform.DOMove(target.position - offSet, 0f);
        }
    }
}
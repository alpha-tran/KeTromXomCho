using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private bool _isDead = false;

        private void OnEnable()
        {
            this.Register(Enums.EventID.PlayerJump, PlayJumpAnim);
            this.Register(Enums.EventID.PlayerHitGround, PlayRunAnim);
            this.Register(Enums.EventID.PlayerHitTrap, PlayHurtAnim);
            this.Register(Enums.EventID.PlayerDead, PlayDeadAnim);


        }

        private void OnDisable()
        {
            this.Unregister(Enums.EventID.PlayerJump, PlayJumpAnim);
            this.Unregister(Enums.EventID.PlayerHitGround, PlayRunAnim);
            this.Unregister(Enums.EventID.PlayerHitTrap, PlayHurtAnim);
            this.Unregister(Enums.EventID.PlayerDead, PlayDeadAnim);

        }

        private void PlayHurtAnim(object obj)
        {
            if(_isDead) return;
            _animator.Play("PlayerHurt");
        }

        private void PlayRunAnim(object obj)
        {
            _animator.Play("PlayerRun");
        }

        private void PlayJumpAnim(object obj)
        {
            _animator.Play("PlayerJump");
        }

        private void PlayDeadAnim(object obj)
        {
            _isDead = true;
            _animator.Play("PlayerDead");
        }
    }
}


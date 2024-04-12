using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Game.Gameplay
{
    public class EnemyAnimController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private string _hitAnim;


        private void OnEnable()
        {
            this.Register(Enums.EventID.PlayerHitTrap, PlayHitAnim);
        }

        private void OnDisable()
        {
            this.Unregister(Enums.EventID.PlayerHitTrap, PlayHitAnim);
        }

        private void PlayHitAnim(object obj)
        {
            if((obj as Enemy) == (_enemy))
            {
                _animator.Play(_hitAnim);
            }
        }
    }
}


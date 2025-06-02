using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZAssets.Scripts.Animation;

namespace EZAssets.Scripts.GamePlay.Controller.EnemyAI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private AnimatorHandler _animatorHandler;
        private bool _isKnockedOut = false;

        void Start()
        {
            _animatorHandler.PlayAnimation(CharacterAnimationState.Idle);
        }

        private void Update()
        {
            if (_isKnockedOut) return;

            // Debug control để test animation
            if (Input.GetKeyDown(KeyCode.Alpha1)) Attack(CharacterAnimationState.HeadPunch);
            if (Input.GetKeyDown(KeyCode.Alpha2)) TakeHit(CharacterAnimationState.HeadHit);
            if (Input.GetKeyDown(KeyCode.Alpha3)) Attack(CharacterAnimationState.KidneyPunchLeft);
            if (Input.GetKeyDown(KeyCode.Alpha4)) Attack(CharacterAnimationState.KidneyPunchRight);
            if (Input.GetKeyDown(KeyCode.Alpha5)) TakeHit(CharacterAnimationState.KidneyHit);
            if (Input.GetKeyDown(KeyCode.Alpha6)) Attack(CharacterAnimationState.StomachPunch);
            if (Input.GetKeyDown(KeyCode.Alpha7)) TakeHit(CharacterAnimationState.StomachHit);
            if (Input.GetKeyDown(KeyCode.K)) KnockOut();
        }

        public void Attack(CharacterAnimationState attackType)
        {
            _animatorHandler.PlayAnimation(attackType);
        }

        public void TakeHit(CharacterAnimationState hitType)
        {
            _animatorHandler.PlayAnimation(hitType);
        }

        public void KnockOut()
        {
            _isKnockedOut = true;
            _animatorHandler.PlayAnimation(CharacterAnimationState.KnockedOut);
        }

        public void Idle()
        {
            _animatorHandler.PlayAnimation(CharacterAnimationState.Idle);
        }
    }
}



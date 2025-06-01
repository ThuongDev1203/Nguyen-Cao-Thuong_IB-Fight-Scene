using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EZAssets.Scripts.Animation
{
    public class AnimatorHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;


        public void PlayAnimation(CharacterAnimationState state)
        {
            switch (state)
            {
                case CharacterAnimationState.Idle:
                    _animator.Play("Idle");
                    break;

                case CharacterAnimationState.HeadPunch:
                    _animator.SetTrigger("HeadPunch");
                    break;

                case CharacterAnimationState.HeadHit:
                    _animator.SetTrigger("HeadHit");
                    break;

                case CharacterAnimationState.KidneyPunchLeft:
                    _animator.SetTrigger("KidneyPunchLeft");
                    break;

                case CharacterAnimationState.KidneyPunchRight:
                    _animator.SetTrigger("KidneyPunchRight");
                    break;

                case CharacterAnimationState.KidneyHit:
                    _animator.SetTrigger("KidneyHit");
                    break;

                case CharacterAnimationState.StomachPunch:
                    _animator.SetTrigger("StomachPunch");
                    break;

                case CharacterAnimationState.StomachHit:
                    _animator.SetTrigger("StomachHit");
                    break;

                case CharacterAnimationState.KnockedOut:
                    _animator.SetTrigger("KnockedOut");
                    break;
            }
        }
    }
}


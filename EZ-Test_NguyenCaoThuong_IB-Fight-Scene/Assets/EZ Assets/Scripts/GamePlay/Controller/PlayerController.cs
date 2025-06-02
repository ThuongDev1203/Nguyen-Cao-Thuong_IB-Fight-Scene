using System.Collections;
using System.Collections.Generic;
using EZAssets.Scripts.Animation;
using EZAssets.Scripts.SO;
using UnityEngine;

namespace EZAssets.Scripts.GamePlay.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("So Reference")]
        [SerializeField] private PlayerSO _playerSO;

        [Header("Combat")]
        [SerializeField] private AnimatorHandler _animatorHandler;

        [Header("Combat Settings")]
        [SerializeField] private float attackCooldown = 0.5f;

        private Vector2 _touchStartPos;
        private bool _isSwiping = false;
        private float _minSwipeDistance = 50f;

        void Start()
        {
            PlayIdleAnimation();
        }

        void Update()
        {
            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                HandleTouch();
            }
            else
            {
                HandleMouse();
            }
        }

        private void HandleTouch()
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPos = touch.position;
                    _isSwiping = true;
                    break;

                case TouchPhase.Ended:
                    if (!_isSwiping) return;
                    HandleSwipeOrTap(touch.position);
                    _isSwiping = false;
                    break;
            }
        }

        private void HandleMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchStartPos = Input.mousePosition;
                _isSwiping = true;
            }
            else if (Input.GetMouseButtonUp(0) && _isSwiping)
            {
                HandleSwipeOrTap(Input.mousePosition);
                _isSwiping = false;
            }
        }

        private void HandleSwipeOrTap(Vector2 endPos)
        {
            Vector2 swipeDelta = endPos - _touchStartPos;

            if (swipeDelta.magnitude >= _minSwipeDistance)
            {
                if (swipeDelta.y > 0 && Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
                {
                    PlayStomachPunch();
                }
                else if (swipeDelta.x > 0 && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    PlayKidneyPunchLeft();
                }
                else if (swipeDelta.x < 0 && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    PlayKidneyPunchRight();
                }
                else
                {
                    PlayHeadPunch();
                }
            }
            else
            {
                PlayHeadPunch();
            }
        }

        // Animation functions
        private void PlayIdleAnimation()
        {
            _animatorHandler?.PlayAnimation(CharacterAnimationState.Idle);
        }

        private void PlayKidneyPunchLeft()
        {
            _animatorHandler?.PlayAnimation(CharacterAnimationState.KidneyPunchLeft);
        }

        private void PlayKidneyPunchRight()
        {
            _animatorHandler?.PlayAnimation(CharacterAnimationState.KidneyPunchRight);
        }

        private void PlayHeadPunch()
        {
            _animatorHandler?.PlayAnimation(CharacterAnimationState.HeadPunch);
        }

        private void PlayStomachPunch()
        {
            _animatorHandler?.PlayAnimation(CharacterAnimationState.StomachPunch);
        }
    }
}

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
            _animatorHandler.PlayAnimation(CharacterAnimationState.Idle);
        }

        void Update()
        {
            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
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

                        Vector2 touchEndPos = touch.position;
                        Vector2 swipeDelta = touchEndPos - _touchStartPos;

                        if (swipeDelta.magnitude >= _minSwipeDistance)
                        {
                            if (swipeDelta.x > 0 && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                            {
                                _animatorHandler?.PlayAnimation(CharacterAnimationState.KidneyPunchLeft);
                            }
                            else
                            {
                                _animatorHandler?.PlayAnimation(CharacterAnimationState.KidneyPunchRight);
                            }
                        }
                        else
                        {
                            _animatorHandler?.PlayAnimation(CharacterAnimationState.HeadPunch);
                        }

                        _isSwiping = false;
                        break;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _touchStartPos = Input.mousePosition;
                    _isSwiping = true;
                }
                else if (Input.GetMouseButtonUp(0) && _isSwiping)
                {
                    Vector2 touchEndPos = Input.mousePosition;
                    Vector2 swipeDelta = touchEndPos - _touchStartPos;

                    if (swipeDelta.magnitude >= _minSwipeDistance)
                    {
                        if (swipeDelta.x > 0 && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                        {
                            _animatorHandler?.PlayAnimation(CharacterAnimationState.KidneyPunchLeft);
                        }
                        else
                        {
                            _animatorHandler?.PlayAnimation(CharacterAnimationState.KidneyPunchRight);
                        }
                    }
                    else
                    {
                        _animatorHandler?.PlayAnimation(CharacterAnimationState.HeadPunch);
                    }

                    _isSwiping = false;
                }
            }
        }
    }
}

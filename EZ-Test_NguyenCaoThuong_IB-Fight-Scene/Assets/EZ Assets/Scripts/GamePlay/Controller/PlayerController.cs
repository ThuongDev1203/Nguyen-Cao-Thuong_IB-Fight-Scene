using System.Collections;
using System.Collections.Generic;
using EZAssets.Scripts.SO;
using UnityEngine;
namespace EZAssets.Scripts.GamePlay.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("So Reference")]
        [SerializeField] private PlayerSO _playerSO;

        [Header("Combat")]
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            HandleMovement();
            if (Input.GetMouseButtonDown(0))
            {
                HandleCombat();
            }

        }

        private void HandleMovement()
        {

        }

        private void HandleCombat()
        {

        }
    }
}

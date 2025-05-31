using System.Collections;
using System.Collections.Generic;
using EZAssets.Scripts.Data;
using UnityEngine;

namespace EZAssets.Scripts.SO
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "EZAssets/PlayerSO")]
    public class PlayerSO : ScriptableObject
    {
        [SerializeField]
        private PlayerData _playerData;

        public PlayerData PlayerData => _playerData;
    }
}

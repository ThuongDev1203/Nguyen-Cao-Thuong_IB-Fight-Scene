using System.Collections;
using System.Collections.Generic;
using EZAssets.Scripts.Data;
using UnityEngine;

namespace EZAssets.Scripts.SO
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "EZAssets/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        [SerializeField]
        private EnemyData _enemyData;

        public EnemyData EnemyData => _enemyData;
    }
}

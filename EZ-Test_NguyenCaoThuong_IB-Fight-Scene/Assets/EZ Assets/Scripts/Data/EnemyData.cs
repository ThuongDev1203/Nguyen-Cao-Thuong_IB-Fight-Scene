using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EZAssets.Scripts.Data
{
    [SelectionBase]
    public class EnemyData
    {
        [Header("Data")]
        [SerializeField] private Guid _id;
        [SerializeField] private string _enemyName;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackRange;

        public Guid Id { get { if (_id == Guid.Empty) _id = Guid.NewGuid(); return _id; } set { _id = value; } }
        public string EnemyName { get { return _enemyName; } }
        public int MaxHealth { get { return _maxHealth; } }
        public int Damage { get { return _damage; } }
        public float AttackRange { get { return _attackRange; } }

        public override string ToString()
        {
            return $"[Id: {Id}, Name: {EnemyName}, MaxHealth: {MaxHealth}, Damage: {Damage}, AttackRange: {AttackRange}]";
        }
    }
}

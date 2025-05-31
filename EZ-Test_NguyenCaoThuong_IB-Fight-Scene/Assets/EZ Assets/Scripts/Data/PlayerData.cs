using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EZAssets.Scripts.Data
{
    [Serializable]
    public class PlayerData
    {
        [Header("Data")]
        [SerializeField] private Guid _id;
        [SerializeField] private string _playerName;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _attackRange;

        public Guid Id { get { if (_id == Guid.Empty) _id = Guid.NewGuid(); return _id; } set { _id = value; } }
        public string PlayerName { get { return _playerName; } }
        public int MaxHealth { get { return _maxHealth; } }
        public int Damage { get { return _damage; } }
        public float MoveSpeed { get { return _moveSpeed; } }
        public float AttackRange { get { return _attackRange; } }

        public override string ToString()
        {
            return $"[Id: {Id}, Name: {PlayerName}, MaxHealth: {MaxHealth}, Damage: {Damage}, MoveSpeed: {MoveSpeed}, AttackRange: {AttackRange}]";
        }
    }
}


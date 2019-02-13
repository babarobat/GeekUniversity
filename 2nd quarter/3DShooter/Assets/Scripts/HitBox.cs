﻿using System;
using UnityEngine;
using Game.Interfaces;

namespace Game.Components
{
    [RequireComponent(typeof(Collider))]
    class HitBox : MonoBehaviour, IDamageble
    {
        public event Action<float> OnHit;
        [SerializeField]
        [Range(0,10)]
        private float _damageMultiplyer;
        public void GetDamage(DamageInfo damageInfo)
        {
            var currentDamage = damageInfo.Damage * _damageMultiplyer;
            OnHit?.Invoke(currentDamage);
            
        }
    }
}
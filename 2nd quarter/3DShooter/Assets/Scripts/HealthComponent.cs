using System;
using UnityEngine;

namespace Game.Components
{
    class HealthComponent : BaseObjectScene
    {
        [SerializeField]
        [Range(0,100)]
        private float _startHealth;
        private float _currentHealth;
        public float StartHealth => _startHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                OnHpChange?.Invoke(value);
                if (_currentHealth <= 0)
                {
                    _currentHealth = 0;
                    Dead();
                    
                }
            }
        }
        private HitBox[] _hitboxes;
        public event Action<float> OnHpChange;
        public event Action OnDead;
        protected override void Awake()
        {
            base.Awake();
            _hitboxes = GetComponentsInChildren<HitBox>();
            _currentHealth = _startHealth;
            foreach (var item in _hitboxes)
            {
                item.OnHit += ChangeHp;
            }
        }
        void ChangeHp(float value)
        {
            CurrentHealth -= value;
        }
        void Dead()
        {
            foreach (var item in _hitboxes)
            {
                item.OnHit -= ChangeHp;
            }
            OnDead?.Invoke();
        }

    }
}

using System;
using UnityEngine;

namespace Game.Controllers
{
    
    public class HealthController:BaseComponentController,IDamage
    {
        [SerializeField]
        private float _startHp;

        private float _currentHp;
        
        public float CurrentHp
        {
            get => _currentHp;
            private set
            {
                _currentHp = value < 0 ? 0 : value;
                OnHpChange?.Invoke(_currentHp);

                if (_currentHp == 0)
                {
                    HpIsZero?.Invoke();
                }
            }
        }
        public event Action<float> OnHpChange;
        public event Action HpIsZero;

        public void GetDamage(int damage)
        {
            CurrentHp -=  damage; 
        }
        protected override void Start()
        {
            base.Start();
            
            CurrentHp = _startHp;
        }


    }
}

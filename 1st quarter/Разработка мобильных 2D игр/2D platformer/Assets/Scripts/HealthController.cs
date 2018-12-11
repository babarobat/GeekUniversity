using System;
using UnityEngine;

namespace Game.Controllers
{

    class HealthController:BaseComponentController,IDamage
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
                OnHpChange(_currentHp);
                if (_currentHp == 0)
                {
                    HpIsZero();
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
        }


    }
}

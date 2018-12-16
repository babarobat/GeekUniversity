using System;
using UnityEngine;

namespace Game.Controllers
{
    
    public class HealthController:BaseComponentController,IDamage
    {
        [SerializeField]
        private int _startHp;
        public int StartHp => _startHp;
        private int _currentHp;
        
        public int CurrentHp
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
        public event Action<int> OnHpChange;
        public event Action HpIsZero;

        public void GetDamage(int damage)
        {
            CurrentHp -=  damage; 
        }
        protected override void Start()
        {
            base.Start();
            _currentHp = StartHp;
        }
        public void ResetParams()
        {
            _currentHp = StartHp;
            OnHpChange?.Invoke(_currentHp);
        }


    }
}

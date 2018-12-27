using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Controllers
{
    class Boss:BaseEnemyController
    {
        private BossState _currentSate = BossState.Sleeping;
        [SerializeField]
        Trigger _activasionTrigger;


        protected override void Start()
        {
            base.Start();
            _activasionTrigger.OnEnter += ActivateBoss;
            _hp.OnHpChange += OnHpChange;
        }
        private void Update()
        {

            print(_currentSate.ToString());
            switch (_currentSate)
            {
                case BossState.Sleeping:
                    break;
                case BossState.One:
                    break;
                case BossState.Two:
                    break;
                case BossState.Three:
                    break;
                case BossState.ChangingState:
                    break;
                
            }
        }
        void Patrol()
        {

        }
        void ActivateBoss(TriggerEventArgs e)
        {
            _currentSate = BossState.One;
        }
        void OnHpChange(int value)
        {
            _currentSate = value > (_hp.StartHp / 3) * 2 ? BossState.One : value > (_hp.StartHp / 3) ? BossState.Two : BossState.Three;
           
        }
    }
}

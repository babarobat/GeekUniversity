using UnityEngine;
using System;

namespace Game.Controllers
{
    class FlyingRobot:BaseEnemyController
    {
        private FieldOfViewController _fow;
        private WeaponController _weaponController;
        private float _attackDistance;
        private bool _canAttack;
        
        protected override  void Start()
        {
            base.Start();
            _fow = GetComponentInChildren<FieldOfViewController>();
            _weaponController = GetComponentInChildren<WeaponController>();
            
            _target = _fow.Target;
        }

        private void Update()
        {
            if (_fow.Target==null)
            {
                Patrol();
            }
            else
            {
                
                LookAtTarget();
                GoToAttackPos();
                Attack();
            }

            
        }
        void Patrol()
        {
            
            if (_patrolPoints.Length>1)
            {
                
                _movementController.MoveToTarget(_patrolPoints[_patrolPointIndex].position, Speed);
                if (Vector2.Distance(transform.position, _patrolPoints[_patrolPointIndex].position)<.1f)
                {
                    if (_patrolPointIndex< _patrolPoints.Length-1)
                    {
                        _patrolPointIndex += 1;
                    }
                    else
                    {
                        _patrolPointIndex = 0;
                    }
                }
            }
            
        }
       
        
        public void LookAtTarget()
        {
            
            _movementController.LookAtTarget(_fow.Target);
            _fow.LookAtTarget();
        }
        void GoToAttackPos()
        {
            var attackPos =  new Vector2(transform.position.x,_fow.Target.transform.position.y);
            if (Vector2.Distance(attackPos,transform.position)>0.1f)
            {
                _movementController.MoveToTarget(attackPos, Speed);
                _canAttack = false;

            }
            else
            {
                _canAttack = true;
                _movementController.Stop();
            }
            
        }
        void Attack()
        {
            if (_canAttack)
            {
                _weaponController.Fire();
            }
            
        }
        
        
    }
}

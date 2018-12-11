using UnityEngine;
using System;
using System.Collections;

namespace Game.Controllers
{
    class FlyingRobot:BaseEnemyController
    {
        
        private WeaponController _weaponController;
        private float _attackDistance;
        private bool _canAttack;
        bool _isAngry;
        bool keppFolowing = true;

        
        
        protected override  void Start()
        {
            base.Start();            
            _weaponController = GetComponentInChildren<WeaponController>();
            
            
        }
        
        private void LateUpdate()
        {
            
            
            if (_fow.Target != null)
            {
                _isAngry = true;

            }
            if (_isAngry)
            {
                LookAtTarget();
                GoToAttackPos();
                Attack();
                if (_fow.Target == null)
                {
                    if (keppFolowing)
                    {
                        StartCoroutine(KeepFolowing(2));
                    }
                }
            }
            else
            {
                Patrol();
            }     
        }
        
        IEnumerator KeepFolowing(float time)
        {
            keppFolowing = false;
            yield return new WaitForSeconds(time);
            keppFolowing = true;
            _isAngry = false;
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
            _movementController.LookAtTarget(_target);
            _fow.LookAtTarget(_target);
        }
        void GoToAttackPos()
        {
            var attackPos =  new Vector2(transform.position.x,_target.transform.position.y);
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

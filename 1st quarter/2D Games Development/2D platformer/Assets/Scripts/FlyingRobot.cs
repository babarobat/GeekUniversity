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
        

        private SoundController _soundController;
        
        protected override  void Start()
        {
            base.Start();            
            _weaponController = GetComponentInChildren<WeaponController>();
            _soundController = GetComponentInChildren<SoundController>();
            _hp.OnHpChange += Attacked;
           
        }
        void Attacked(int hp)
        {
            _isAngry = true;
        }
        private void LateUpdate()
        {


            if (_fow.Target != null)
            {
                _isAngry = true;

            }
            if (_isAngry)
            {
                if (!_soundController.SoundIsPlaying("Alarm"))
                {
                    _soundController.PlaySound("Alarm", true);
                    _soundController.StopSound("Searching");
                }
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
                if (!_soundController.SoundIsPlaying("Searching"))
                {
                    _soundController.StopSound("Alarm");
                    _soundController.PlaySound("Searching", true);
                }
                
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
                _movementController.MoveToTarget(_patrolPoints[_patrolPointIndex].position, Speed * Time.deltaTime);
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
            _movementController.LookAtTarget(_target.transform);
            _fow.LookAtTarget(_target.transform);
        }
        void GoToAttackPos()
        {
            var attackPos =  new Vector2(transform.position.x,_target.transform.position.y-.5f);
            if (Vector2.Distance(attackPos,transform.position)>0.1f)
            {
                _movementController.MoveToTarget(attackPos, Speed *Time.deltaTime);
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
        public void PlaySound(string name)
        {
            _soundController.PlaySound(name, false);
        }
        
    }
}

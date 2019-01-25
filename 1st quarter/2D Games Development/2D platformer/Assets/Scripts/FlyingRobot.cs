using UnityEngine;
using System;
using System.Collections;

namespace Game.Controllers
{
    class FlyingRobot:BaseEnemyController
    {
        
        private WeaponController _weaponController;
        
        private bool _canAttack;
        bool _isAngry;
        bool keppFolowing = true;
        [SerializeField]
        private float _agroSpeed;
        float _normalRadius;
        float _currentRadious;
        private SoundController _soundController;
        
        protected override  void Start()
        {
            
            base.Start();
            _normalRadius = _fow.ViewRadius;

            _weaponController = GetComponentInChildren<WeaponController>();
            _soundController = GetComponentInChildren<SoundController>();
            _hp.OnHpChange += Attacked;
            _target.OnPlayerDead += StopFollow;
           
        }
        void StopFollow()
        {
            _isAngry = false;
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
                goToAttack = true;
                //GoToAttackPos();
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
                goToAttack = false;
                //Patrol();
            }
        }
        bool goToAttack;
        private void FixedUpdate()
        {
            if (goToAttack)
            {
                GoToAttackPos();
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
            _fow.ViewRadius = _normalRadius;
           

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
            _currentRadious = Vector2.Distance(transform.position, _target.transform.position);
            _fow.ViewRadius = _currentRadious;
            _fow.LookAtTarget(_target.transform);
        }
        void GoToAttackPos()
        {
            var minattackdistance = transform.position.x > _target.transform.position.x + _normalRadius/2 ? _target.transform.position.x + _normalRadius/2 :
                                   transform.position.x < _target.transform.position.x - _normalRadius/2 ? _target.transform.position.x - _normalRadius/2 :
                                                                                          transform.position.x;
           
            var attackPos =  new Vector2(minattackdistance, _target.transform.position.y-.3f);
            _canAttack =Mathf.Abs ( transform.position.x - _target.transform.position.x) <= _normalRadius &&
                        Mathf.Abs( transform.position.y - _target.transform.position.y) <= 1;

            if (Vector2.Distance(attackPos,transform.position)>0.1f)
            {
                _movementController.MoveToTarget(attackPos, _agroSpeed * Time.deltaTime);
                
            }
            else
            {
               
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

﻿using UnityEngine;
using System.Collections;
using Game.Audio;
namespace Game.Controllers
{
    /// <summary>
    /// Логика и параметры врага Dog
    /// </summary>
    class Dog:BaseEnemyController
    {
        /// <summary>
        /// Позиция цели
        /// </summary>
        private Vector2 _targetPos;
        /// <summary>
        /// Зол ли враг
        /// </summary>
        bool _isAngry;
        /// <summary>
        /// Патрулирует от точки до точки из списка patrolPoints по оси Х.  
        /// </summary>
        /// /// <summary>
        /// Продолжает гнаться после потери цели?
        /// </summary>
        bool keepFolowing = true;
        float _currentRadious;
        float _normalRadius;
        [SerializeField]
        SoundComponent _sound;
        private void FixedUpdate()
        {
            PatrollAndAttack();
        }

        void Patrol()
        {
            if (_patrolPoints.Length > 1)
            {
                
                _targetPos.x = _patrolPoints[_patrolPointIndex].position.x;
                _targetPos.y = transform.position.y;
                if (transform.position.x < _targetPos.x)
                {
                    _movementController.Move(Speed*Time.fixedDeltaTime);
                }
                else
                {
                    _movementController.Move(-Speed * Time.fixedDeltaTime);
                }
                
                if (Vector2.Distance(transform.position, _patrolPoints[_patrolPointIndex].position) < 1f)
                {
                    if (_patrolPointIndex < _patrolPoints.Length - 1)
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
        /// <summary>
        /// Двигается к цели _targetPos
        /// </summary>
        void MoveToTarget()
        {
            _targetPos.x = _target.transform.position.x;
            _targetPos.y = transform.position.y;
            _currentRadious = Vector2.Distance(transform.position, _target.transform.position);
            _fow.ViewRadius = _currentRadious;
            _fow.LookAtTarget(_target.transform);
            
            if (transform.position.x < _targetPos.x)
            {
                _movementController.Move( Speed * 2f *Time.fixedDeltaTime);
            }
            else
            {
                _movementController.Move(-Speed * 2f *Time.fixedDeltaTime);
            }
            
        }
        /// <summary>
        /// Продолжает гнатсья за целью после потери из поля зрения
        /// </summary>
        /// <param name="time">время преследовнания после потери из поля зрения</param>
        /// <returns></returns>
        IEnumerator KeepFolowing(float time) 
        {
            keepFolowing = false;
            yield return new WaitForSeconds(time);
            keepFolowing = true;
            _fow.ViewRadius = _normalRadius;
            _fow.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            //_fow.transform.rotation = Quaternion.Euler(_fow.transform.rotation.eulerAngles.x, _fow.transform.rotation.eulerAngles.y, 0);
            _isAngry = false;
        }
        /// <summary>
        /// патрулирует местность, При абнаружении цели гонится за ней
        /// </summary>
        private void PatrollAndAttack()
        {
            if (_fow.Target != null)
            {
                _isAngry = true;
            }
            if (_isAngry)
            {
                if (!_sound.SoundIsPlaying("DogAgro"))
                {
                    _sound.Play("DogAgro");
                    
                }
                MoveToTarget();
                if (_fow.Target == null)
                {
                    if (keepFolowing)
                    {
                        StartCoroutine(KeepFolowing(1));
                    }
                }
            }
            else
            {
                if (!_sound.SoundIsPlaying("DogMove"))
                {
                    _sound.Play("DogMove");

                }
                Patrol();
            }
        }
        
        protected override void Start()
        {
            
            base.Start();
            _normalRadius = _fow.ViewRadius;
            _hp.OnHpChange += Angreed;
        }
        void Angreed(int value)
        {
            _isAngry = true;
        }
    }
}

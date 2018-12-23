using UnityEngine;
using System.Collections;

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
            _targetPos.x = _target.position.x;
            _targetPos.y = transform.position.y;
            _fow.LookAtTarget(_target);
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
                Patrol();
            }
        } 


    }
}

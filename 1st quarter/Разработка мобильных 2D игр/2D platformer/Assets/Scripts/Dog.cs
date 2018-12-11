using UnityEngine;
using System;
using System.Collections;

namespace Game.Controllers
{

    /// <summary>
    /// Логика и параметры врага Dog
    /// </summary>

    
    class Dog:BaseEnemyController
    {

        private Vector2 targetPos;
        bool _isAngry;
        void Patrol()
        {
            if (_patrolPoints.Length > 1)
            {
                targetPos.x = _patrolPoints[_patrolPointIndex].position.x;
                targetPos.y = transform.position.y;
                _movementController.MoveToTarget(targetPos, Speed);
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
        void MoveToTarget()
        {
            targetPos.x = _target.position.x;
            targetPos.y = transform.position.y;
            _fow.LookAtTarget(_target);
            _movementController.MoveToTarget(targetPos,Speed*2f);
        }
        private void Update()
        {
            if (_fow.Target!=null)
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
        bool keepFolowing = true;
        IEnumerator KeepFolowing(float time) 
        {
            keepFolowing = false;
            yield return new WaitForSeconds(time);
            keepFolowing = true;
            _fow.transform.rotation = Quaternion.Euler(_fow.transform.rotation.eulerAngles.x, _fow.transform.rotation.eulerAngles.y, 0);
            _isAngry = false;
        }

    }
}

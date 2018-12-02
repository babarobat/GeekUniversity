using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Логика и параметры врага Dog
    /// </summary>
    class Dog:BaseEnemyController
    {
        private void Update()
        {
            PatrolAndFollow();
        }
        /// <summary>
        /// Устанавливает параметр _targetPos в зависисмости от текущего местоположения
        /// </summary>
        private void Patrol()
        {
            if (_patrolPoints.Length>=2)
            {
                if (Vector2.Distance(_patrolPoints[patrolPointIndex].position, transform.position) < 0.5)
                {
                    patrolPointIndex = patrolPointIndex < _patrolPoints.Length - 1 ? patrolPointIndex + 1 : 0;
                }
                else
                {
                    _targetPos.x = _patrolPoints[patrolPointIndex].position.x;
                    _targetPos.y = transform.position.y;
                    _currentSpeed = Speed;  
                }
            }   
        }
        /// <summary>
        /// Устанавливает параметр _targetPos в зависимости от текущего местоположения цели
        /// </summary>
        private void FollowTarget()
        {
            _targetPos.x = _target.position.x;
            _targetPos.y = transform.position.y;
            _currentSpeed = _followSpeed;
        }
        /// <summary>
        /// В зависимости от расстояния до цели заставляет персонажа либьо гнаться за целью, либо патрулировать
        /// </summary>
        private void PatrolAndFollow()
        {
            var dir = transform.rotation.eulerAngles.y == 180 ? -1 : 1;
            _hit = Physics2D.Raycast(_rayCastPoint.position, Vector2.right * dir, _agroRadius);
            if (Vector2.Distance(_target.position, transform.position) <= _agroRadius && _hit.collider?.tag == "Player")
            {
                FollowTarget();
            }
            else
            {
                Patrol();
            }
            _movementController.MoveToTarget(_targetPos, _currentSpeed);
        }
    }
}

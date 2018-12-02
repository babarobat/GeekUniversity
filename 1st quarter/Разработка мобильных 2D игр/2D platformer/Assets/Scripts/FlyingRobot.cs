using UnityEngine;

namespace Game.Controllers
{
    class FlyingRobot:BaseEnemyController
    {
        private WeaponController _weaponController;
        [SerializeField] private float _attackDistance;

        protected override void Start()
        {
            base.Start();
            _weaponController = GetComponentInChildren<WeaponController>();
        }
        private void FollowTarget()
        {
            _targetPos = _target.position;
            _currentSpeed = _followSpeed;
        }
        private void Patrol()
        {
            if (_patrolPoints.Length >= 2)
            {
                if (Vector2.Distance(_patrolPoints[patrolPointIndex].position, transform.position) < 0.5)
                {
                    patrolPointIndex = patrolPointIndex < _patrolPoints.Length - 1 ? patrolPointIndex + 1 : 0;
                }
                else
                {
                    _targetPos = _patrolPoints[patrolPointIndex].position;
                    _currentSpeed = Speed;
                }
            }
            
        }
    }
}

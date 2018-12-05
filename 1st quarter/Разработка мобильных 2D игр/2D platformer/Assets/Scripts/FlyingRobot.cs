using UnityEngine;

namespace Game.Controllers
{
    class FlyingRobot:BaseEnemyController
    {
        [SerializeField]
        private float _viewAngle;



        private WeaponController _weaponController;
        [SerializeField] private float _attackDistance;

        protected override void Start()
        {
            base.Start();
            _weaponController = GetComponentInChildren<WeaponController>();
        }
        private void Update()
        {
            All();
            _movementController.MoveToTarget(_targetPos, Speed);
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
        private void Attack()
        {
            if (Mathf.Abs( transform.position.y - _target.position.y)<=1)
            {
                
                _weaponController.Fire();
            }
            
        }
        private void All()
        {
            if (Vector2.Distance(_target.position,transform.position)<=_agroRadius)
            {
                MoveToAttackPos();
                Attack();
            }
            else
            {
                Patrol();
            }
        }
        private void MoveToAttackPos()
        {
            _targetPos.y = _target.position.y;
            _targetPos.x = transform.position.x;
        }
    }
}

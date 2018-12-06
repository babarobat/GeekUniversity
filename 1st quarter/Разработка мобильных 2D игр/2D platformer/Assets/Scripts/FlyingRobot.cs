using UnityEngine;

namespace Game.Controllers
{
    class FlyingRobot:BaseEnemyController
    {
        [SerializeField]
        private float _viewAngle;



        private WeaponController _weaponController;
        [SerializeField] private float _attackDistance;
        private FieldOfViewController _fieldOfViewController;


        protected override void Start()
        {
            base.Start();
            _weaponController = GetComponentInChildren<WeaponController>();
            _fieldOfViewController = GetComponentInChildren<FieldOfViewController>();
        }
        private void Update()
        {
            All();
            
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
            _fieldOfViewController.SearchTarget();
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
            
            if (_fieldOfViewController.Target == null)
            {
                Patrol();
                _movementController.MoveToTarget(_targetPos, Speed);
            }
            else
            {
                LookAtTarget();
                if (Mathf.Abs(transform.position.y - _targetPos.y)>.1)
                {
                    print(3);
                    MoveToAttackPos();
                    _movementController.MoveToTarget(_targetPos, Speed);
                }
                else
                {
                    _movementController.Stop();
                    _weaponController.Fire();
                }
            }

        }
        private void MoveToAttackPos()
        {
            _targetPos.y = _target.position.y;
            _targetPos.x = transform.position.x;
        }
        void LookAtTarget()
        {
            _fieldOfViewController.LookAtTarget(_target);
        }
    }
}

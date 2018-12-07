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
            Patrol();
            
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
            _movementController.MoveToTarget(_targetPos, Speed);
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
            
            

        }
        private void MoveToAttackPos()
        {
            _targetPos.y = _target.position.y;
            _targetPos.x = transform.position.x;
        }
        
    }
}

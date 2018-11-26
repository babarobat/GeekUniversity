using UnityEngine;

namespace Game.Controllers
{
    class Dog:BaseEnemyController
    {
        private RaycastHit2D _hit = new RaycastHit2D();
        [SerializeField] private Transform _rayCastPoint;
        private void Update()
        {
            _hit = Physics2D.Raycast(_rayCastPoint.position, Vector3.right*transform.localScale.x, _agroRadius);
            if (Vector2.Distance(_target.position,transform.position)<=_agroRadius &&_hit.collider?.tag == "Player")
            {
                FollowTarget();
            }
            else
            {
                
                Patrol();
            }
        }

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
                    _movementController.MoveTo(_patrolPoints[patrolPointIndex], Speed);
                }
            }
            
        }
        private void FollowTarget()
        {
            if (transform.position.x < _target.position.x)
            {
                _movementController.Move(_followSpeed);
            }
            else
            {
                _movementController.Move(-_followSpeed);
            }
        }
    }
}

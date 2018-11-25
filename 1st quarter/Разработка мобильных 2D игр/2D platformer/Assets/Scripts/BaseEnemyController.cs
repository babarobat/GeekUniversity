using UnityEngine;

namespace Game.Controllers
{
    class BaseEnemyController:BaseCharacterController
    {
        [SerializeField] protected float _agroRadius;
        [SerializeField] protected float _followSpeed;
        [SerializeField] protected Transform[] _patrolPoints;
        protected Transform _target;
        protected bool _isMad;
        
        protected int patrolPointIndex = 0;
        protected override void Start()
        {
            base.Start();
            _target = FindObjectOfType<PlayerController>().transform;
        }
        private void OnDrawGizmosSelected()
        {
            //Gizmos.DrawWireSphere(transform.position, _agroRadius);
            Gizmos.DrawLine(transform.position, transform.position+Vector3.right);
        }

    }
}

using Game.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Game.Components;
namespace Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(HealthComponent))]
    public class Enemy :BaseObjectScene
    {
        [SerializeField]
        [Range(0,20)]
        private float _agroRange = 5;
        public float AgroRange =>_agroRange;
        [SerializeField]
        [Range(0, 360)]
        private float _viewAngle = 90;
        public float ViewAngle => _viewAngle;

        private NavMeshAgent _agent;
        private HealthComponent _health;
        [SerializeField]
        private Transform [] _patrolPoints;
        
        private bool _isDead;
        
        IVision _vision;
        [SerializeField]
        private BaseWeapon _weapon;

        protected override void Awake()
        {
            base.Awake();
            PlayerMoveModel target = FindObjectOfType<PlayerMoveModel>();
            _weapon.Selected = true;
            _vision = new EnemyVision(target.Transform, _agroRange, _viewAngle);
            _isDead = false;
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<HealthComponent>();
            _health.OnDead += Dead;
        }
        private void FixedUpdate()
        {
            if (_isDead) return;

            var target = _vision.GetTarget(Transform);
            if (target)
            {
                Stop();
                LookAtTarget(target.position);
                Attack();
            }
            else
            {
                Patrol();
            }
        }
        
        void Patrol()
        {
            if (_agent.isStopped)
            {
                _agent.isStopped = false;
            }
            if (!_agent.hasPath)
            {
                MoveToTarget(GetNewRandomPoint());
            }
        }
        Vector3 GetNewRandomPoint()
        {
            return _patrolPoints[Random.Range(0, _patrolPoints.Length)].position;
        }
        void Dead()
        {
            _isDead = true;
            _agent.enabled = false;
            Destroy(gameObject, 30);
            
        }
        void Attack()
        {
            if (_weapon.CanFire)
            {
                _weapon.Fire();
            }
        }
        void MoveToTarget(Vector3 target)
        {
            _agent.SetDestination(target);
        }
        void Stop()
        {
            _agent.isStopped = true;
        }
        void LookAtTarget(Vector3 target)
        {

            Transform.LookAt(new Vector3(target.x, Transform.position.y, target.z));
        }
        
  
    }
}


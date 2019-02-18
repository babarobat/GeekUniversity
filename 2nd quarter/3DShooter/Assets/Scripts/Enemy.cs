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

        protected override void Awake()
        {
            base.Awake();
            PlayerMoveModel target = FindObjectOfType<PlayerMoveModel>();
            
            _vision = new EnemyVision(target.Transform, _agroRange, _viewAngle);
            _isDead = false;
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<HealthComponent>();
            _health.OnDead += Dead;
            
        }
        
        private void Update()
        {
            print(_vision.GetTarget(Transform)?.name);
            Patrol();
        }
        void Patrol()
        {

            if (!_agent.hasPath && !_isDead)
            {
                _agent.SetDestination(GetNewRandomPoint());
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
            CrazyDeath(transform);
            foreach (var item in tmp)
            {
                item.parent = null;
                Destroy(item.gameObject, 30);
            }
            Destroy(gameObject, 30);
        }
        System.Collections.Generic.List<Transform> tmp = new System.Collections.Generic.List<Transform>();
        

        void CrazyDeath(Transform x)
        {
            var anim = x.GetComponent<Animator>();
            if (anim != null)
            {
                Destroy(anim);
            }
            if (x.GetComponent<Rigidbody>() == null && x.GetComponent<Renderer>() != null)
            {
                var r = x.gameObject.AddComponent<Rigidbody>();
                r.AddForce(Vector3.up * 50);
                
                x.gameObject.AddComponent<SimpleHeatbleObj>();
                //r.velocity = Vector3.zero;
            }
            
            tmp.Add(x);
            if (x.childCount == 0) return;
            foreach (Transform item in x.transform)
            {
                CrazyDeath(item);
            }
        } 
    }
}



using UnityEngine;
using UnityEngine.AI;
using Game.Components;
namespace Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(HealthComponent))]
    public class Enemy :BaseObjectScene
    {

        private NavMeshAgent _agent;
        private HealthComponent _health;
        [SerializeField]
        private Transform [] _patrolPoints;
        float _viewAngle;
        float _viewDistance;



        protected override void Awake()
        {
            base.Awake();
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<HealthComponent>();
            _health.OnDead += Dead;
            
        }
        private void OnDrawGizmos()
        {
            
        }
        private void Update()
        {
            Patrol();
        }
        void Patrol()
        {
            if (!_agent.hasPath)
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
                //r.velocity = Vector3.zero;
            }
            if (x.GetComponent<Collider>() == null && x.GetComponent<Renderer>() != null)
            {
                x.gameObject.AddComponent<CapsuleCollider>();
                x.gameObject.AddComponent<SimpleHeatbleObj>();
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


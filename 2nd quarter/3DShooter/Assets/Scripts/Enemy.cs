
using UnityEngine;
using UnityEngine.AI;
using Game.Components;
namespace Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(HealthComponent))]
    public class Enemy :BaseObjectScene  {
        NavMeshAgent _agent;
        HealthComponent _health;
        protected override void Awake()
        {
            base.Awake();
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<HealthComponent>();
            _health.OnDead += Dead;
            
        }

        void Dead()
        {
            Crazy(transform);
            Destroy(gameObject, 30);
        }
        void Crazy(Transform x)
        {
            //if (GetComponent<MeshRenderer>()!=null)
            //{
            //    print(x.name);
            //}

            var anim = GetComponentInChildren<Animator>();
            _agent.enabled = false;
            if (anim != null)
            {
                Destroy(anim);
            }

            if (GetComponent<Rigidbody>() == null)
            {
                
                
                var r = x.gameObject.AddComponent<Rigidbody>();
                r.velocity = Vector3.zero;
            }
            if (GetComponent<Collider>() != null)
            {
                x.gameObject.AddComponent<CapsuleCollider>();
            }

            x.gameObject.AddComponent<SimpleHeatbleObj>();

            if (x.childCount <= 0) return;
            foreach (Transform item in x.transform)
            {
                Crazy(item);
            }
            x.SetParent(transform.root);
        }

    }
}


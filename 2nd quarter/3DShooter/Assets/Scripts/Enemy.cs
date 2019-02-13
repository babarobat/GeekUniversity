
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
            _agent.enabled = false;
            Crazy(transform);
            foreach (var item in tmp)
            {
                item.parent = null;
                Destroy(item.gameObject, 30);
            }
            Destroy(gameObject, 30);
        }
        System.Collections.Generic.List<Transform> tmp = new System.Collections.Generic.List<Transform>();
        void Crazy(Transform x)
        {
            #region MyRegion



            var anim = x.GetComponent<Animator>();

            if (anim != null)
            {
                Destroy(anim);
            }

            if (x.GetComponent<Rigidbody>() == null && x.GetComponent<Renderer>() != null)
            {
                var r = x.gameObject.AddComponent<Rigidbody>();
                //r.velocity = Vector3.zero;
            }
            if (x.GetComponent<Collider>() == null && x.GetComponent<Renderer>() != null)
            {
                x.gameObject.AddComponent<CapsuleCollider>();
                x.gameObject.AddComponent<SimpleHeatbleObj>();
            }

            #endregion
            tmp.Add(x);
            if (x.childCount == 0) return;
            foreach (Transform item in x.transform)
            {
                Crazy(item);
            }
            
        }

    }
}


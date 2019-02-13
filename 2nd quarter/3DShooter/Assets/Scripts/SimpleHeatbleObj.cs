using System;
using Game.Interfaces;
using UnityEngine;

namespace Game
{
    [RequireComponent (typeof(Rigidbody)), RequireComponent(typeof(Collider)),]
    class SimpleHeatbleObj :BaseObjectScene, IDamageble
    {
        Rigidbody _rb;
        protected override void Awake()
        {
            base.Awake();
            _rb = GetComponent<Rigidbody>();
        }
       
            
        
        public void GetDamage(DamageInfo damageInfo)
        {
            
            var dir = transform.position - damageInfo.From;
            _rb.AddForce(dir*100);
        }
    }
}

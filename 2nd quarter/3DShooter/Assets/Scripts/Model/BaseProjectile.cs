using System;
using UnityEngine;
using Game.Interfaces;


namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    
    public abstract class BaseProjectile : BaseObjectScene
    {
        public float Damage { get; set; }
        public float Speed { get; set; }
        public WeaponType Type { get; set; }

        protected Rigidbody _rb;
        
        private DamageInfo _damageInfo;

        protected override void Awake()
        {
            base.Awake();
            _rb = GetComponent<Rigidbody>();
            _damageInfo = new DamageInfo();
            
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            var tmp = collision.transform.GetComponent<IDamageble>();
            if (tmp != null)
            {
                _damageInfo.Damage = Damage;
                _damageInfo.From = Transform.position;
                _damageInfo.Type = Type;
                tmp.GetDamage(_damageInfo);
            }
            BeforeDestroy();
            Destroy(gameObject);
        }
         protected virtual void BeforeDestroy()
        {
            print(name + "Destroyed");
        }
        public abstract void Move();

    }
}

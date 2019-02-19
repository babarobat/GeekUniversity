using System;
using UnityEngine;

namespace Game
{
    class Rocket : BaseProjectile
    {
        private readonly float lifeTime = 5;
        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, lifeTime);
        }
        public override void Move()
        {
            _rb.velocity = Transform.forward * Speed;
        }
    }
}

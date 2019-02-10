using System;
using UnityEngine;

namespace Game
{
    class RayCastBasedWepon : BaseWeapon
    {
        private RaycastHit _hit;
        private const float shotDistance = 100;
        protected override void Awake()
        {
            base.Awake();
            _hit = new RaycastHit();
        }
        public override void Fire()
        {
            if (Physics.Raycast(_firePoint.position,
                                _firePoint.transform.TransformDirection(Vector3.forward * shotDistance),
                                out _hit))

            {
                print(_hit.transform.GetComponent<ISelectable>().Info);
            }
        }
    }
}

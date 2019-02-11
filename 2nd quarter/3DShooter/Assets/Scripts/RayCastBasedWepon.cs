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
            _canFire = true;
        }
        public override void Fire()
        {
            
            if (_canFire)
            {
                
                if (Physics.Raycast(_firePoint.position,
                                _firePoint.transform.TransformDirection(Vector3.forward * shotDistance),
                                out _hit))

                {
                    //_canFire = false;
                    print(_hit.transform.name);
                    print(_hit.transform.GetComponent<ISelectable>()?.Info.Info);
                    Invoke(nameof(Reload), _fireRate);
                }
            }
            
        }
        void Reload()
        {
            _canFire = true;
        }
        
    }
    
}

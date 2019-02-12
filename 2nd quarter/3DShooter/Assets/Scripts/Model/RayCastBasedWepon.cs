using System;
using System.Collections;
using UnityEngine;
using Game.Interfaces;

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
            if (_canFire)
            {
                Shot();
                if (_currentBulletsInClip<1)
                {
                    Reload();
                }
                else
                {
                    WaitToFire();
                }
            }
        }
        void AllowFire()
        {
            _canFire = true;
        }
        
        void WaitToFire()
        {
            Invoke(nameof(AllowFire), _fireRate);
        }
        void Shot()
        {
            if (_currentBulletsInClip>0)
            {
                _canFire = false;
                _currentBulletsInClip--;
                CallOnAmmoChange();


                if (Physics.Raycast(_firePoint.position,
                                       _firePoint.transform.TransformDirection(Vector3.forward * shotDistance),
                                       out _hit))

                {
                   _hit.transform.GetComponent<IDamageble>()?.GetDamage(_damageInfo);
                }
            }
            else
            {
                CallNoBullets();
            }  
        }
    }
}
    


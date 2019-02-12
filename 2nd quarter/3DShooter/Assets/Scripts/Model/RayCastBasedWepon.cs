using System;
using System.Collections;
using UnityEngine;
using Game.Interfaces;

namespace Game
{
    /// <summary>
    /// Оружие, основанное на RayCast
    /// </summary>
    class RayCastBasedWepon : BaseWeapon
    {
        /// <summary>
        /// Информация о попадании луча
        /// </summary>
        private RaycastHit _hit;
        /// <summary>
        /// дальгность стрельбы
        /// </summary>
        private const float shotDistance = 100;

        protected override void Awake()
        {
            base.Awake();
            _hit = new RaycastHit();   
        }
        /// <summary>
        /// Выстрелить
        /// </summary>
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
        /// <summary>
        /// разрешить стрелять
        /// </summary>
        void AllowFire()
        {
            _canFire = true;
        }
        /// <summary>
        /// Ждать и потом разрешить стрелять
        /// </summary>
        void WaitToFire()
        {
            Invoke(nameof(AllowFire), _fireRate);
        }
        /// <summary>
        /// Сделать выстрел
        /// </summary>
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
    


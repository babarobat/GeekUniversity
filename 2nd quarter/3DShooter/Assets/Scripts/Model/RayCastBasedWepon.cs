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

        private Vector3 _crossHairPoint;
        Camera _head;

        protected override void Awake()
        {
            base.Awake();
            _hit = new RaycastHit();
            _crossHairPoint = new Vector3(.5f, .5f,0);
            _head = Main.Instance.MainCamera;
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

                var center =_head.ViewportToWorldPoint(_crossHairPoint);
                if (Physics.Raycast(center,
                                       _head.transform.forward*100,
                                       out _hit))

                {
                   
                    var target = _hit.transform.GetComponent<IDamageble>();
                    if (target != null)
                    {

                        _damageInfo.Damage = _damage;
                        _damageInfo.From = transform.position;
                        target.GetDamage(_damageInfo);
                    }
                   
                }
            }
            else
            {
                CallNoBullets();
            }  
        }
       

    }
}
    


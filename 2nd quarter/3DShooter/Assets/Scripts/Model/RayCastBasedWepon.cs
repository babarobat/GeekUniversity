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

        new Vector3 _firePoint;
        Camera _head;

        protected override void Awake()
        {
            base.Awake();
            _hit = new RaycastHit();
            _firePoint = new Vector3(.5f, .5f,0);
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

                var center =_head.ViewportToWorldPoint(_firePoint);
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
        private void OnDrawGizmos()
        {
            Debug.DrawLine(FindObjectOfType<Camera>().ViewportToWorldPoint(new Vector3(.5f, .5f, 0)), FindObjectOfType<Camera>().transform.forward*100);
        }

    }
}
    


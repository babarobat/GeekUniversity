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
        /// дальгность стрельбы
        /// </summary>
        private const float shotDistance = 100;

        private Vector2 _crossHairPoint;
        Camera _head;

        protected override void Awake()
        {
            base.Awake();
            
            _crossHairPoint = new Vector3(Screen.width/2, Screen.height/2);
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

                var center =_head.ScreenToWorldPoint(_crossHairPoint);
                RaycastHit hit; 
                if (Physics.Raycast(center, _head.transform.forward*100
                                       ,
                                       out hit))
                {
                    print(hit.transform.name);
                    var target = hit.transform.GetComponent<IDamageble>();
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
            var center = FindObjectOfType<Camera>().ScreenToWorldPoint(_crossHairPoint);
            Debug.DrawRay(center, FindObjectOfType<Camera>().transform.forward*100);
        }
    }
}
    


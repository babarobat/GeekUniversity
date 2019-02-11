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

                    if (_clip.CurrentBulletsCount == 0)
                    {
                        Reload();
                    }
                    else
                    {
                        Shot();
                        WaitToFire();
                    }
                    print(_hit.transform.GetComponent<ISelectable>()?.Info.Info);

                }
            }

        }
        void CanFire()
        {
            _canFire = true;
        }
        void Reload()
        {
            Invoke(nameof(CanFire), _reloadTime);
        }
        void WaitToFire()
        {
            Invoke(nameof(CanFire), _fireRate);
        }
        void Shot()
        {
            _canFire = false;
            _clip.CurrentBulletsCount--;
        }
    }


}
    


using System;
using UnityEngine;

namespace Game
{
    class ProjectileBasedWeapon : BaseWeapon
    {
        [SerializeField]
        private float _ammoSpeed;
        
        [SerializeField]
        private BaseProjectile _projectilePefab;

        protected override void Shot()
        {
            if (_currentBulletsInClip>0)
            {
                _canFire = false;
                _currentBulletsInClip--;
                CallOnAmmoChange();

                var tmpProj = Instantiate(_projectilePefab, _firePoint.position, _firePoint.rotation);
                tmpProj.Speed = _ammoSpeed;
                tmpProj.Damage = _damage;
                tmpProj.Type = _type;
                tmpProj.Move();
            }
            else
            {
                CallNoBullets();
            } 
        }
    }
}

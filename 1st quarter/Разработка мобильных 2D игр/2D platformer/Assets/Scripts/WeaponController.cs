using UnityEngine;
using System;
using System.Linq;

namespace Game.Controllers
{
   /// <summary>
   /// Логика м параметры компонента, управляющего стрельбой
   /// </summary>
    public class WeaponController:BaseComponentController
    {
        /// <summary>
        /// Список оружия
        /// </summary>
        public BaseWeapon[] Weapons;
        /// <summary>
        /// Выбранное оружие
        /// </summary>
        public BaseWeapon ActiveWeapon
        {
            get
            {
                return Array.Find(Weapons, e => e.IsActive == true);
            }
        }
        /// <summary>
        /// Стрельнуть в заданном направлении
        /// </summary>
        /// <param name="dir">напрваление стрельбы</param>
        public void Fire()
        {
            
            ActiveWeapon?.Fire();
        }
    }
}

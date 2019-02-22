using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class InventoryModel:BaseObjectScene
    {
        [SerializeField]
        BaseWeapon[] _allWeapons;
        BaseWeapon[] _weaponsInInventory;

        protected override void Awake()
        {
            base.Awake();
            _weaponsInInventory = new BaseWeapon[7];
        }
        public void PickItem(WeaponType type)
        {
            //if (_weaponsInInventory.Contains())
            //{

            //
            //switch (switch_on)
            //{
            //    default:
            //}
        }
    }
}

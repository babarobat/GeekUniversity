using UnityEngine;
namespace Game
{
    public class ArsenalModel:BaseObjectScene
    {
        [SerializeField]
        private BaseWeapon[] _weapons;
        public BaseWeapon[] Weapons => _weapons;

        
    }
}

using UnityEngine;
namespace Game
{
    class WeaponsModel:BaseObjectScene
    {
        [SerializeField]
        BaseWeapon[] _weapons;
        BaseWeapon[] Weapons => _weapons;
    }
}

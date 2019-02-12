using UnityEngine;
namespace Game
{
    /// <summary>
    /// Параметры арсенала игрока
    /// </summary>
    public class ArsenalModel:BaseObjectScene
    {
        /// <summary>
        /// Список оружия
        /// </summary>
        [SerializeField]
        private BaseWeapon[] _weapons;
        /// <summary>
        /// Список оружия
        /// </summary>
        public BaseWeapon[] Weapons => _weapons;

        
    }
}

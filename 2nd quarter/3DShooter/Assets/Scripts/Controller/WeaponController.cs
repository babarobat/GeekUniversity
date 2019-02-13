using Game.Interfaces;
using UnityEngine;
namespace Game
{
    /// <summary>
    /// Содердит логику управления оружием и стрельбой
    /// </summary>
    class WeaponController:BaseController,IUpdate
    {
        /// <summary>
        /// Ссылка на параметры арсенала
        /// </summary>
        private ArsenalModel _weaponsModel;
        /// <summary>
        /// Ссылка на обьект, отвечающий за отображение арсенала
        /// </summary>
        private AmmunitionView _weaponsView;
        /// <summary>
        /// индекс выбраного оружия
        /// </summary>
        private int _activeWeaponIndex;
        /// <summary>
        /// Ссылка на обьект, содержащий команды пользовательского ввода
        /// </summary>
        private IInput _input;

        public WeaponController(IInput input)
        {
            _weaponsModel = MonoBehaviour.FindObjectOfType<ArsenalModel>();          
            _weaponsView = MonoBehaviour.FindObjectOfType<AmmunitionView>();
            _input = input;

            BaseWeapon.OnAmmoChange += _weaponsView.UpdateWeaponsView;
            BaseWeapon.OnReload += _weaponsView.ShowReloadMessage;
            BaseWeapon.NoBullets += _weaponsView.ShowNoBulletsMess;
            BaseWeapon.NoClips += _weaponsView.ShowNoClipsMessage;

            _input.OnLeftMouseDown += Fire;
            _input.OnReload += Reload;

            HideAllWeapons();
            ActiveWeopnIndex = 0;
            ShowWeapon(ActiveWeopnIndex);
        }
        /// <summary>
        /// Перезарядить выбраное оружие
        /// </summary>
        void Reload()
        {
            _weaponsModel?.Weapons[ActiveWeopnIndex].Reload();
        }

        /// <summary>
        /// Спрятать все оружия
        /// </summary>
        private void HideAllWeapons()
        {
            foreach (var item in _weaponsModel.Weapons)
            {
                item.Selected = false;
            }
        }
        /// <summary>
        /// Проверяет, входит ли индекс в пределы допустимого значения
        /// </summary>
        /// <param name="index"></param>
        void CheckIndex(int index)
        {
            if (index < 0 || index >= _weaponsModel.Weapons.Length) throw new System.Exception("Неверный индекс оружия оружия");
        }
        /// <summary>
        /// Спрятать оружие
        /// </summary>
        /// <param name="index"></param>
        private void HideWeapon(int index)
        {
            CheckIndex(index);
            _weaponsModel.Weapons[index].Selected = false;
        }
        /// <summary>
        /// Достать оружие
        /// </summary>
        /// <param name="index"></param>
        private void ShowWeapon(int index)
        {
            CheckIndex(index);
            _weaponsModel.Weapons[index].Selected = true;
        }
        /// <summary>
        /// Выстрелить из выбраного оружия
        /// </summary>
        public void Fire()
        {
            if (_weaponsModel.Weapons[ActiveWeopnIndex].CanFire)
            {
                _weaponsModel?.Weapons[ActiveWeopnIndex].Fire();
            }
        }
        /// <summary>
        /// Выбрать следующее оружие
        /// </summary>
        void ChooseNextWeapon()
        {
            HideWeapon(_activeWeaponIndex);
            ActiveWeopnIndex++;
            ShowWeapon(_activeWeaponIndex);
        }
        /// <summary>
        /// Выбрать предыдущее оружие
        /// </summary>
        void ChoosePreviousWeopn()
        {
            HideWeapon(_activeWeaponIndex);
            ActiveWeopnIndex--;
            ShowWeapon(_activeWeaponIndex);
        }
        /// <summary>
        /// Индекс выбраного оружия
        /// </summary>
        public int ActiveWeopnIndex
        {
            get => _activeWeaponIndex;
            set => _activeWeaponIndex = value < 0 ? _weaponsModel.Weapons.Length - 1 :
                                        value > _weaponsModel.Weapons.Length - 1 ? 0 :
                                        value;
        }

        public void OnUpdate()
        {

            if (!IsActive) return;
            
            if (_input.GetScrollWheel()>0)
            {
                ChooseNextWeapon();
            }
            if (_input.GetScrollWheel() < 0)
            {
                ChoosePreviousWeopn();
            }
            
        }
    }
}

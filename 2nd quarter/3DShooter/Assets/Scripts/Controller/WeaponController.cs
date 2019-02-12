using Game.Interfaces;
using UnityEngine;
namespace Game
{
    class WeaponController:BaseController,IUpdate
    {
        private ArsenalModel _weaponsModel;
        private AmmunitionView _weaponsView;
        private int _activeWeaponIndex;
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
        void Reload()
        {
            _weaponsModel?.Weapons[ActiveWeopnIndex].Reload();
        }
        private void HideAllWeapons()
        {
            foreach (var item in _weaponsModel.Weapons)
            {
                item.Selected = false;
            }
        }
        void CheckIndex(int index)
        {
            if (index < 0 || index >= _weaponsModel.Weapons.Length) throw new System.Exception("Неверный индекс оружия оружия");
        }
        private void HideWeapon(int index)
        {
            CheckIndex(index);
            _weaponsModel.Weapons[index].Selected = false;
        }
        private void ShowWeapon(int index)
        {
            CheckIndex(index);
            _weaponsModel.Weapons[index].Selected = true;
        }
        public void Fire()
        {
            if (_weaponsModel.Weapons[ActiveWeopnIndex].CanFire)
            {
                _weaponsModel?.Weapons[ActiveWeopnIndex].Fire();
            }
        }
        
        void ChooseNextWeapon()
        {
            HideWeapon(_activeWeaponIndex);
            ActiveWeopnIndex++;
            ShowWeapon(_activeWeaponIndex);
        }
        void ChoosePreviousWeopn()
        {
            HideWeapon(_activeWeaponIndex);
            ActiveWeopnIndex--;
            ShowWeapon(_activeWeaponIndex);
        }
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

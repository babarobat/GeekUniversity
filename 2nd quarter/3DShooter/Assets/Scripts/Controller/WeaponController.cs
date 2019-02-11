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
            HideAllWeapons();
            ActiveWeopnIndex = 0;
            ShowWeapon(ActiveWeopnIndex);
            _input.OnLeftMouseDown += Fire;
        }
        private void HideAllWeapons()
        {
            foreach (var item in _weaponsModel.Weapons)
            {
                item.Selected = false;
            }
        }
        private void HideWeapon(int index)
        {
            if (index < 0 || index >= _weaponsModel.Weapons.Length) throw new System.Exception("Неверный индекс оружия оружия");
            
            _weaponsModel.Weapons[index].IsVisible = false;
        }
        private void ShowWeapon(int index)
        {
            if (index < 0 || index >= _weaponsModel.Weapons.Length) throw new System.Exception("Неверный индекс оружия оружия");
            _weaponsModel.Weapons[index].IsVisible = true;
        }
        public void Fire()
        {
            _weaponsModel?.Weapons[ActiveWeopnIndex].Fire();
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

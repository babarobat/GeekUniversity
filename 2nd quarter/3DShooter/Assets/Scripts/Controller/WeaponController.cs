using Game.Interfaces;
namespace Game
{
    class WeaponController:BaseController
    {
        private ArsenalModel _weaponsModel;
        private AmmunitionView _weaponsView;

        private int _activeWeaponIndex;
        private IInput _input;
        public WeaponController(IInput input, ArsenalModel weaponsModel)
        {
            _weaponsModel = weaponsModel;
            //_weaponsView = view;
            _input = input;
            HideAllWeapons();
            _activeWeaponIndex = 0;
            ShowWeapon(_activeWeaponIndex);
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
            
            _weaponsModel?.Weapons[_activeWeaponIndex].Fire();
        }

        
    }
}

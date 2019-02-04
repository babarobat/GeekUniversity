using UnityEngine;

namespace Game
{
    /// <summary>
    /// Управление фонарем
    /// </summary>
    class FlashLightController : BaseController
    {
        /// <summary>
        /// Параметры фонаря
        /// </summary>
        private FlashLightModel _flashLightModel;
        /// <summary>
        /// Отображение параметров фонаря
        /// </summary>
        private FlashLightView _flashLightView;
        public FlashLightController()
        {
            _flashLightModel = MonoBehaviour.FindObjectOfType<FlashLightModel>();
            _flashLightView = MonoBehaviour.FindObjectOfType<FlashLightView>();
            Main.Instance.GetInputController.OnFPressed += Switch;
            
        }
        /// <summary>
        /// Выключение фонаря
        /// </summary>
        public override void Off()
        {

            if (!IsActive ) return;
            base.Off();
            _flashLightModel?.Switch(false);
            
        }
        /// <summary>
        /// Включение фонаря
        /// </summary>
        public override void On()
        {
            if (IsActive ) return;
            
            base.On();
            _flashLightModel?.Switch(true);
            
        }
        
        public override void OnUpdate()
        {
            
            if (_flashLightModel == null) return;
           
            _flashLightView.Text = _flashLightModel.BatteryChargeCurrent;
            if (IsActive)
            {
                if (!_flashLightModel.Disсharge())
                {
                    Off();
                }
            }
            else
            {
                _flashLightModel.Charge();
            }
            _flashLightModel.Rotate();
            
            
        }
    }
}

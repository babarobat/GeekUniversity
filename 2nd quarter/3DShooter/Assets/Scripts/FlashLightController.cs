using UnityEngine;

namespace Game
{
    class FlashLightController : BaseController
    {
        private FlashLightModel _flashLightModel;
        private FlashLightView _flashLightView;
        public FlashLightController()
        {
            _flashLightModel = MonoBehaviour.FindObjectOfType<FlashLightModel>();
            _flashLightView = MonoBehaviour.FindObjectOfType<FlashLightView>();
            Main.Instance.GetInputController.FPressed += Switch;
            
        }
        
        public override void Off()
        {

            if (!IsActive ) return;
            base.Off();
            _flashLightModel?.Switch(false);
            
        }

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

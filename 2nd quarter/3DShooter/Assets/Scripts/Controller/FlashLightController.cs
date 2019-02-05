using UnityEngine;

namespace Game
{
    /// <summary>
    /// Управление фонарем
    /// </summary>
    class FlashLightController : BaseController
    {
        /// <summary>
        /// Трансформ, за которым слудует фонарь
        /// </summary>
        private Transform _follow;

       

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
            _follow = MonoBehaviour.FindObjectOfType<Camera>().transform;
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
            Switch(false);
            
        }
        /// <summary>
        /// Включение фонаря
        /// </summary>
        public override void On()
        {
            if (IsActive ) return;
            
            base.On();
            Switch(true);
            
        }
        
        public override void OnUpdate()
        {
            
            if (_flashLightModel == null) return;
           
            _flashLightView.Text = _flashLightModel.BatteryChargeCurrent;
            if (IsActive)
            {
                if (!Disсharge())
                {
                    Off();
                }
            }
            else
            {
                Charge();
            }
            Rotate();
        }
        /// <summary>
        /// Вкл/кыкл фонарика в зависисмости от данного знаяения
        /// </summary>
        /// <param name="value"></param>
        public void Switch(bool value)
        {
            _flashLightModel.Light.enabled = value;
            if (!value) return;
            _flashLightModel.Transform.position = _follow.position; //+ _offset;
            _flashLightModel.Transform.rotation = _follow.localRotation;
        }
        /// <summary>
        /// Поворачивает фонарь вместе с камерой, если он включен
        /// </summary>
        public void Rotate()
        {
            if (!_flashLightModel.Light) return;

            _flashLightModel.Transform.position = _follow.position;
            _flashLightModel.Transform.rotation = Quaternion.Lerp(_flashLightModel.transform.rotation,
                                                                  _follow.rotation,
                                                                  _flashLightModel.FollowSpeed * Time.deltaTime);
        }
        /// <summary>
        /// Заряжает фонарь. Возвращает false когда зарядился
        /// </summary>
        /// <returns></returns>
        public bool Charge()
        {
            if (!_flashLightModel.Charged)
            {
                _flashLightModel.BatteryChargeCurrent += Time.deltaTime * _flashLightModel.DisсhargeSpeed;
                return true;
            }
            return false;

        }
        /// <summary>
        /// Разряжает фонарь. Возвращает false когда разрядился
        /// </summary>
        /// <returns></returns>
        public bool Disсharge()
        {
            if (!_flashLightModel.Empty)
            {
                _flashLightModel.BatteryChargeCurrent -= Time.deltaTime * _flashLightModel.DisсhargeSpeed;
                return true;
            }
            return false;
        }
    }
}

using UnityEngine;

namespace Game
{
    /// <summary>
    /// Параметры и логика фонарика
    /// </summary>
    public sealed class FlashLightModel : BaseObjectScene
    {
        /// <summary>
        /// Ссылка на компонент Light
        /// </summary>
        private Light _light;
        /// <summary>
        /// Компонент Light
        /// </summary>
        public Light Light => _light;
        /// <summary>
        /// Трансформ, за которым слудует фонарь
        /// </summary>
        private Transform _follow;
        
        private Vector3 _offset;

        /// <summary>
        /// Текущий заряд батареи
        /// </summary>
        public float BatteryChargeCurrent { get; private set; }
        /// <summary>
        /// Скорость передвижения фонаря
        /// </summary>
        [SerializeField] private float _moveSpeed = 10;
        /// <summary>
        /// Максемальный заряд батареи
        /// </summary>
        [SerializeField] private float _batteryChargeMax;
        /// <summary>
        /// Скорость разрядки
        /// </summary>
        [SerializeField] private float _disсhargeSpeed;
        /// <summary>
        /// Скорость зарядки
        /// </summary>
        [SerializeField] private float _chargeSpeed;


        protected override void Awake()
        {
            base.Awake();
            _light = GetComponentInChildren<Light>();
            _follow = FindObjectOfType<Camera>().transform;
            _offset = transform.position - _follow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }
        /// <summary>
        /// Вкл/кыкл фонарика в зависисмости от данного знаяения
        /// </summary>
        /// <param name="value"></param>
        public void Switch(bool value)
        {
            _light.enabled = value;
            if (!value) return;
            Transform.position = _follow.position + _offset;
            Transform.rotation = _follow.localRotation;
        }
        /// <summary>
        /// Поворачивает фонарь вместе с камерой, если он включен
        /// </summary>
        public void Rotate()
        {
            if (!_light) return;
            
            Transform.position = _follow.position + _offset;
            Transform.rotation = Quaternion.Lerp(transform.rotation, _follow.rotation, _moveSpeed * Time.deltaTime);
        }
        /// <summary>
        /// Разряжает фонарь. Возвращает false когда разрядился
        /// </summary>
        /// <returns></returns>
        public bool Disсharge()
        {
            if (BatteryChargeCurrent>0)
            {
                BatteryChargeCurrent -= Time.deltaTime* _disсhargeSpeed;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Заряжает фонарь. Возвращает false когда зарядился
        /// </summary>
        /// <returns></returns>
        public bool Charge()
        {
            if (BatteryChargeCurrent <= _batteryChargeMax)
            {
                BatteryChargeCurrent += Time.deltaTime * _disсhargeSpeed;
                return true;
            }
            return false;
            
        }
    }
}

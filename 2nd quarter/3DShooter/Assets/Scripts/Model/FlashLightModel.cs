using UnityEngine;

namespace Game
{
    /// <summary>
    /// Параметры и логика фонарика
    /// </summary>
    [RequireComponent(typeof(Light))]
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
        /// Текущий заряд батареи
        /// </summary>
        public float BatteryChargeCurrent
        {
            get => _batteryChargeCurrent;
            set
            {
                _batteryChargeCurrent = value < 0 ? 0 : value;
            }
        }
        /// <summary>
        /// Текущий заряд батареи
        /// </summary>
        private float _batteryChargeCurrent;
        /// <summary>
        /// Скорость передвижения фонаря
        /// </summary>
        [SerializeField] private float _followSpeed = 10;
        /// <summary>
        /// Скорость передвижения фонаря
        /// </summary>
        public float FollowSpeed => _followSpeed;
        /// <summary>
        /// Максемальный заряд батареи
        /// </summary>
        [SerializeField] private float _batteryChargeMax;
        /// <summary>
        /// Максемальный заряд батареи
        /// </summary>
        public float BatteryChargeMax => _batteryChargeMax;
        /// <summary>
        /// Скорость разрядки
        /// </summary>
        [SerializeField] private float _disсhargeSpeed;
        /// <summary>
        /// Скорость разрядки
        /// </summary>
        public float DisсhargeSpeed => _disсhargeSpeed;
        /// <summary>
        /// Скорость зарядки
        /// </summary>
        [SerializeField] private float _chargeSpeed;
        /// <summary>
        /// Скорость зарядки
        /// </summary>
        public float ChargeSpeed => _chargeSpeed;

        protected override void Awake()
        {
            base.Awake();
            
            _light = GetComponent<Light>();
            BatteryChargeCurrent = _batteryChargeMax;
        }
        /// <summary>
        ///  Фонарь заряжен?
        /// </summary>
        public bool Charged => _batteryChargeCurrent >= _batteryChargeMax;
        /// <summary>
        /// Фонарь разряжен?
        /// </summary>
        public bool Empty => _batteryChargeCurrent <= 0;




    }
}

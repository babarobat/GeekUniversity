namespace Game.Controllers
{
    /// <summary>
    /// Структура для хранения параметров управления
    /// </summary>
    [System.Serializable]
    public class ControlParams
    {
        /// <summary>
        /// Значение движения по горизонтали. 
        /// Возвращает -1 при нажатой кнопке влево,
        /// 1 при нажатой кнопке вправо и 0,
        /// если по оси Horizontal нет сигнала
        /// </summary>
        public float Horizontal;//{ get; set; }
        /// <summary>
        /// Возвращает true, если нажата кнопка, назначенная на ось Jump
        /// </summary>
        public bool Jump;// { get; set; }
        /// <summary>
        /// Возвращает true, если нажата кнопка, назначенная на ось Fire1
        /// </summary>
        public bool Fire;// { get; set; }
        /// <summary>
        /// Возвращает true, если нажата кнопка E
        /// </summary>
        public bool Interacting;
    }
}

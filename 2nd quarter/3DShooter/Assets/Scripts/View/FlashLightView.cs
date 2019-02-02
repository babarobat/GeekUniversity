using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    /// <summary>
    /// Логика отображения параметров фанаря
    /// </summary>
    class FlashLightView:MonoBehaviour
    {
        /// <summary>
        /// Текстовое поле для отображения заряда фонарика
        /// </summary>
        private Text _text;
        private void Start()
        {
            _text = GetComponentInChildren<Text>();
        }
        /// <summary>
        /// Отображает заряд фонарика
        /// </summary>
        public float Text
        {
            set => _text.text = $"{ value:0.0}";
        }
        /// <summary>
        /// Выключает обьект, отображающий заряд фонарика
        /// </summary>
        /// <param name="value"></param>
        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}

using UnityEngine;

namespace Game
{
    /// <summary>
    /// Сожержит логику и параметры состояний игры
    /// </summary>
    class COnditionController:MonoBehaviour
    {
        /// <summary>
        /// Изменяет время
        /// </summary>
        /// <param name="value"></param>
        public void ChangeTime(float value)
        {
            Time.timeScale = value < 0 ? 0 : value;
        }
        
    }
}

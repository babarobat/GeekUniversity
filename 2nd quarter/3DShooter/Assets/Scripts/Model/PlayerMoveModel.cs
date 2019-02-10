using UnityEngine;

namespace Game
{
    class PlayerMoveModel:BaseObjectScene
    {
        /// <summary>
        /// Скорость поворота камеры
        /// </summary>
        [SerializeField]
        [Range(0, 300)]
        private float _mouseSensivity;
        /// <summary>
        /// Скорость поворота камеры
        /// </summary>
        public float MouseSensivity => _mouseSensivity;
        /// <summary>
        /// Скорость движения персонажа по Vertical
        /// </summary>
        [SerializeField]
        [Range(0, 30)]
        float _forwrdSpeed;
        /// <summary>
        /// Скорость движения персонажа по Vertical
        /// </summary>
        public float ForwardSpeed => _forwrdSpeed;
        /// <summary>
        /// Скорость движения персонажа по оси Horizontal
        /// </summary>
        [SerializeField]
        [Range(0, 30)]
        /// <summary>
        /// Скорость движения персонажа по оси Horizontal
        /// </summary>
        float _strafeSpeed;
        /// <summary>
        /// Скорость движения персонажа по оси Horizontal
        /// </summary>
        public float StrafeSpeed => _strafeSpeed;
        
        [SerializeField]
        [Range(0, 20)]
        private float _jumpPower;
        /// <summary>
        /// Сила прыжка
        /// </summary>
        public float JumpPower => _jumpPower;
    }
}

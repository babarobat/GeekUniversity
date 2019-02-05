using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    /// <summary>
    /// Параметры управления игроком
    /// </summary>
    class PlayerModel : BaseObjectScene
    {
        
        /// <summary>
        /// Скорость поворота камеры
        /// </summary>
        [SerializeField][Range(0,300)]
        private float _mouseSensivity;
        /// <summary>
        /// Скорость поворота камеры
        /// </summary>
        public float MouseSensivity => _mouseSensivity;
        /// <summary>
        /// Скорость движения персонажа по Vertical
        /// </summary>
        [SerializeField]
        float _vertAxisMovementSpeed;
        /// <summary>
        /// Скорость движения персонажа по Vertical
        /// </summary>
        public float VertAxisMovementSpeed => _vertAxisMovementSpeed;
        /// <summary>
        /// Скорость движения персонажа по оси Horizontal
        /// </summary>
        [SerializeField]
        /// <summary>
        /// Скорость движения персонажа по оси Horizontal
        /// </summary>
        float _strafeSpeed;
        /// <summary>
        /// Скорость движения персонажа по оси Horizontal
        /// </summary>
        public float StrafeSpeed => _strafeSpeed;
        /// <summary>
        /// Максимальная скорость движения персонажа по Vertical
        /// </summary>
        [SerializeField]
        float _maxVertAxisMoveentSpeed;
        /// <summary>
        /// Максимальная скорость движения персонажа по Vertical
        /// </summary>
        public float MaxMovementSpeed => _maxVertAxisMoveentSpeed;
        /// <summary>
        /// Максимальная скорость движения персонажа по оси Horizontal
        /// </summary>
        [SerializeField]
        float _maxStrafeSpeed;
        /// <summary>
        /// Максимальная скорость движения персонажа по оси Horizontal
        /// </summary>
        public float MaxStrafeSpeed => _maxStrafeSpeed;

        
    }
}


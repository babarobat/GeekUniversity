using UnityEngine;
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
        [SerializeField]
        private float _rotateSpeed;
        /// <summary>
        /// Камера
        /// </summary>
        private Camera _head;

        protected override void Awake()
        {
            base.Awake();
            _head = FindObjectOfType<Camera>();
        }
        /// <summary>
        /// Поворачивает камеру на заданные углы по оси X и Y в градусах
        /// </summary>
        /// <param name="rotation"></param>
        public void RotateInTwoVectors(Vector2 rotation)
        {
            _head. transform.Rotate(0f, rotation.y*_rotateSpeed , 0f, Space.World);
            _head.transform.Rotate(rotation.x* _rotateSpeed, 0f, 0f, Space.Self);  
        }
    }
}


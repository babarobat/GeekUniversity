using UnityEngine;
using System;
namespace Game
{
    /// <summary>
    /// Параметры пользовательского ввода
    /// </summary>
    public class InputController : BaseController
    {
        /// <summary>
        /// Кнопка активации или деактивации фонарика
        /// </summary>
        private KeyCode _codeFlashLight = KeyCode.F;
        /// <summary>
        /// Кнопка взаимодействия
        /// </summary>
        private KeyCode _interract = KeyCode.E;
        /// <summary>
        /// Левая кнопка мыши. 1 - нажата, 0 - нет
        /// </summary>
        private int _leftMouseButton = 0;
        /// <summary>
        /// Значение ввода по оси "Horizontal" . Имеет 3 состояния -1,0 или 1
        /// </summary>
        public float Horizontal { get; private set; }
        /// <summary>
        /// Значение ввода по оси "Verticval" . Имеет 3 состояния -1,0 или 1
        /// </summary>
        public float Vertical { get; private set; }
        /// <summary>
        /// Движение мыши по оси X
        /// </summary>
        public float MouseX { get; private set; }
        /// <summary>
        /// Движение мыши по оси Y
        /// </summary>
        public float MouseY { get; private set; }
        /// <summary>
        /// Событие нажатия на кнопку F
        /// </summary>
        public event Action OnFPressed;
        /// <summary>
        /// Событие нажатия на ЛКМ
        /// </summary>
        public event Action OnLeftMousePressed;
        /// <summary>
        /// Событие нажатия на ЛКМ
        /// </summary>
        public event Action OnEPressed;


        public override  void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_codeFlashLight))
            {
                OnFPressed?.Invoke();
            }
            if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                OnLeftMousePressed?.Invoke();
            }
            if (Input.GetKeyDown(_interract))
            {
                OnEPressed?.Invoke();
            }
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
        }
        
    }
}

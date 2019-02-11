using UnityEngine;
using Game.Interfaces;

namespace Game
{
    /// <summary>
    /// Содержит логику управления передвижэения игроком
    /// </summary>
    class PlayerMoveController : BaseController, IMove
    {
        /// <summary>
        /// Параметры управления игроком
        /// </summary>
        private PlayerMoveModel _playerMovementModel;
        /// <summary>
        /// ссылка на компонент CharacterController
        /// </summary>
        private CharacterController _characterController;
        /// <summary>
        /// Камера
        /// </summary>
        private Camera _head;
        /// <summary>
        /// Сила притяжения
        /// </summary>
        private float _gravityForce;
        /// <summary>
        /// Команды прользовательского ввода
        /// </summary>
        private IInput _input;
        /// <summary>
        /// Направление движения
        /// </summary>
        private Vector3 _moveDirection;
        /// <summary>
        /// Текущий поворот по X
        /// </summary>
        float _currentXAxis;
        /// <summary>
        /// Вектор для поворота камеры
        /// </summary>
        Vector2 _rotationVector;
        /// <summary>
        /// Вектор для вращения камеры
        /// </summary>
        /// <summary>
        /// Максимальный поворот по X
        /// </summary>
        private const float maxXAxis = 90;
        /// <summary>
        /// минимальный поворот по X
        /// </summary>
        private const float minXAxis = -90;
        /// <summary>
        /// Данные пользовательского ввода для вращения каеры
        /// </summary>
        private  Vector2 RotationVector
        {
            get
            {
                _rotationVector.x = _input.GetMosueX();
                _rotationVector.y = _input.GetMosueY();
                return _rotationVector;
            }
        }

        
        public PlayerMoveController( Camera head, IInput input)
        {
            
            _playerMovementModel = MonoBehaviour.FindObjectOfType<PlayerMoveModel>();
            _characterController = _playerMovementModel.gameObject.AddComponent<CharacterController>();
            _head = head;
            _input = input;
            _moveDirection = new Vector3();
        }
        /// <summary>
        /// Двигает игрока
        /// </summary>
        public void Move()
        {
            if (!IsActive) return;
            GamingGravity();
            Movement();
            RotateCam(RotationVector);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Movement()
        {
            if (_characterController.isGrounded)
            {
                
                _moveDirection = _playerMovementModel.transform.right * _playerMovementModel.StrafeSpeed *_input.GetHorizontal() + 
                                 _playerMovementModel.transform.forward* _playerMovementModel.ForwardSpeed * _input.GetVertical();
            }
            _moveDirection.y = _gravityForce;
            _characterController.Move(_moveDirection * Time.deltaTime);
        }
        /// <summary>
        /// Меняет движение игирока по Y в зависимости от состояни - прыжок, падение или нормальное состояние
        /// </summary>
        private void GamingGravity()
        {
            if (!_characterController.isGrounded) _gravityForce -= 30 * Time.deltaTime;
            else _gravityForce = -1;
            if (_input.GetJump()&& _characterController.isGrounded) _gravityForce = _playerMovementModel.JumpPower;

        }
        /// <summary>
        /// Вращает камеру
        /// </summary>
        /// <param name="rotation"></param>
        private void RotateCam(Vector2 rotation)
        {
            _currentXAxis += rotation.y * _playerMovementModel.MouseSensivity * Time.deltaTime;

            if (_currentXAxis > maxXAxis)
            {

                _currentXAxis = maxXAxis;
                rotation.y = 0.0f;
                ClampXAxisRotationToValue(270.0f);
            }
            else if (_currentXAxis < minXAxis)
            {

                _currentXAxis = minXAxis;
                rotation.y = 0.0f;
                ClampXAxisRotationToValue(90f);
            }

            _head.transform.Rotate(-rotation.y * _playerMovementModel.MouseSensivity * Time.deltaTime, 0, 0, Space.Self);
            _playerMovementModel.Transform.Rotate(0, rotation.x * _playerMovementModel.MouseSensivity * Time.deltaTime, 0, Space.World);
        }
        

        
        /// <summary>
        /// Устанавливает значение для вращения по оси Х
        /// </summary>
        /// <param name="value"></param>
        private void ClampXAxisRotationToValue(float value)
        {
            Vector3 eulerRot = _head.transform.eulerAngles;
            eulerRot.x = value;
            _head.transform.eulerAngles = eulerRot;
        }
        
    }
}

using UnityEngine;
namespace Game
{
    /// <summary>
    /// Определяет управление игроком
    /// </summary>
	public class PlayerController : BaseController
	{
        /// <summary>
        /// Текущий поворот по X
        /// </summary>
        float _currentXAxis;
        /// <summary>
        /// Максимальный поворот по X
        /// </summary>
        private const float maxXAxis = 90;
        /// <summary>
        /// минимальный поворот по X
        /// </summary>
        private const float minXAxis = -90;
        
        /// <summary>
        /// Параметры движения вперед
        /// </summary>
        Vector3 _forwardMovement;
        /// <summary>
        /// Параметры движения в бок
        /// </summary>
        Vector3 _strafeMovement;

        /// <summary>
        /// Камера
        /// </summary>
        private Camera _head;

        /// <summary>
        /// Параметры управления игроком
        /// </summary>
        PlayerModel _playerModel;
        /// <summary>
        /// Команды пользовательского ввода
        /// </summary>
        InputController _input;
        /// <summary>
        /// Вектор для поворота камеры
        /// </summary>
        Vector2 _rotationVector;
        /// <summary>
        /// Вектор для вращения камеры
        /// </summary>
        Vector2 RotationVector
        {
            get
            {
                _rotationVector.x = _input.MouseX;
                _rotationVector.y = _input.MouseY;
                return _rotationVector;
            }
        }
        
		public PlayerController()
		{
            _playerModel = MonoBehaviour.FindObjectOfType<PlayerModel>();
            _head = MonoBehaviour.FindObjectOfType<Camera>();
            _input = Main.Instance.GetInputController;
            
            _rotationVector = new Vector3();
            _forwardMovement = new Vector3();
            _strafeMovement = new Vector3();
        }

		public override void OnUpdate()
		{
			if (!IsActive) return;
            Rotate(RotationVector);
            Move(_input.Horizontal, _input.Vertical);

        }
        /// <summary>
        /// Поворачивает камеру на заданные углы по оси X и Y в градусах
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(Vector2 rotation)
        {

            _currentXAxis += rotation.y * _playerModel.MouseSensivity * Time.deltaTime;

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

            _head.transform.Rotate(-rotation.y * _playerModel.MouseSensivity * Time.deltaTime, 0, 0, Space.Self);
            _playerModel.Transform.Rotate(0, rotation.x * _playerModel.MouseSensivity * Time.deltaTime, 0, Space.World);


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
        /// <summary>
        /// Двигает обьект, на котором лежит скрипт _playerModel
        /// </summary>
        /// <param name="hor">Направление движения по оси Hor</param>
        /// <param name="vert">Направление движения по оси Vert</param>
        /// <param name="speedmultyplyer">Коэффициент скорости</param>
        public void Move(float hor, float vert, float speedmultyplyer)
        {
            _forwardMovement = _head.transform.forward * vert * speedmultyplyer * _playerModel.VertAxisMovementSpeed * Time.deltaTime;
            _strafeMovement = _playerModel.Transform.right * hor * speedmultyplyer * _playerModel.StrafeSpeed * Time.deltaTime;

            _playerModel.Rigidbody.AddForce(_forwardMovement);
            _playerModel.Rigidbody.AddForce(_strafeMovement);

            Vector3 movementClamp = new Vector3();
            movementClamp.z = Mathf.Clamp(_playerModel.Rigidbody.velocity.z, -_playerModel.MaxMovementSpeed, _playerModel.MaxMovementSpeed);
            movementClamp.x = Mathf.Clamp(_playerModel.Rigidbody.velocity.x, -_playerModel.MaxStrafeSpeed, _playerModel.MaxStrafeSpeed);
            movementClamp.y = _playerModel.Rigidbody.velocity.y;
            _playerModel.Rigidbody.velocity = movementClamp;
        }
        /// <summary>
        /// Двигает обьект, на котором лежит скрипт _playerModel
        /// </summary>
        ///  /// <param name="hor">Направление движения по оси Hor</param>
        /// <param name="vert">Направление движения по оси Vert</param>
        public void Move(float hor, float vert)
        {
            Move(hor, vert, 1);
        }
    }
}
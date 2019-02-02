using UnityEngine;
namespace Game
{
    /// <summary>
    /// Определяет управление игроком
    /// </summary>
	public class PlayerController : BaseController
	{
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
                _rotationVector.x = -_input.MouseY;
                _rotationVector.y = _input.MouseX;
                return _rotationVector;
            }
        }
        
		public PlayerController()
		{
            _playerModel = MonoBehaviour.FindObjectOfType<PlayerModel>();
            _input = Main.Instance.GetInputController;
            _rotationVector = new Vector3();
        }

		public override void OnUpdate()
		{
			if (!IsActive) return;
            _playerModel.RotateInTwoVectors(RotationVector);

        }
       
	}
}
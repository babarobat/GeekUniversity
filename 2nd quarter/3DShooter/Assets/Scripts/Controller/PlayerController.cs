using UnityEngine;
namespace Game
{
	public class PlayerController : BaseController
	{
        PlayerModel _playerModel;
        InputController _input;
        Vector3 rotationVector;
		public PlayerController()
		{
            _playerModel = MonoBehaviour.FindObjectOfType<PlayerModel>();
            _input = Main.Instance.GetInputController;
            rotationVector = new Vector3();
        }

		public override void OnUpdate()
		{
			if (!IsActive) return;
            rotationVector.y = _input.MouseX;
            rotationVector.x = -_input.MouseY;
            _playerModel.Rotate(rotationVector);

        }
	}
}
﻿using Game.Interfaces;
namespace Game
{
    /// <summary>
    /// Определяет управление игроком
    /// </summary>
	public class PlayerController : BaseController, IUpdate
    {
        /// <summary>
        /// Ссылка на контроллер двидения игрока
        /// </summary>
        IMove _playerMovementController;

        public PlayerController (IMove movementController)
        {
            _playerMovementController = movementController;
            (_playerMovementController as BaseController).On();
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            _playerMovementController.Move();
        }
    }
}
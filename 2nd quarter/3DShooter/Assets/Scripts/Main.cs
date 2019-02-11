﻿using UnityEngine;
using Game.Interfaces;
namespace Game
{
    /// <summary>
    /// Содержит ссылки на контроллеры. Вызывает апдейт у всех контороллеров. Singleton
    /// </summary>
    class Main:SingltonMono<Main>
    {
        /// <summary>
        /// Ссылка на контроллер пользовательского ввода
        /// </summary>
        public InputController InputController { get; private set; }
        //public InputController GetInputController { get; private set; }
        /// <summary>
        /// Ссылка на контроллер фонарика
        /// </summary>
        public FlashLightController FlashLightController { get; private set; }
        /// <summary>
        /// Ссылка на контроллер управления игроком
        /// </summary>
        public PlayerController PlayerController { get; private set; }
        /// <summary>
        /// Ссылка на контроллер выбора игроком обьектов на сцене
        /// </summary>
        public SelectionController SelectionController { get; private set; }

        public WeaponController WeaponController { get; private set; }

        private Camera _mainCamera;

        /// <summary>
        /// Список всех котроллеров
        /// </summary>
        private IUpdate[] _controllers;
        protected override void Awake()
        {
            _mainCamera = FindObjectOfType<Camera>();
            base.Awake();
            //тест
            Cursor.visible = false;
            //конец теста
            InputController = new InputController();
            InputController.On();
            FlashLightController = new FlashLightController(InputController);
            PlayerController = new PlayerController(new PlayerMoveController(_mainCamera, InputController));
            PlayerController.On();
            SelectionController = new SelectionController(InputController);
            SelectionController.On();
            WeaponController = new WeaponController(InputController);
            WeaponController.On();

            _controllers = new IUpdate[4];
            _controllers[0] = InputController;
            _controllers[1] = FlashLightController;
            _controllers[2] = PlayerController;
            _controllers[3] = WeaponController;



        }
        private void Update()
        {
            for (int i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].OnUpdate();
            }            
        }

        
    }
}

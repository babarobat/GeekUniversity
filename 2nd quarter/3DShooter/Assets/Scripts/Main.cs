using UnityEngine;
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

        /// <summary>
        /// Список всех котроллеров
        /// </summary>
        private IUpdate[] _controllers;
        protected override void Awake()
        {

            base.Awake();
            //тест
            Cursor.visible = false;
            //конец теста
            InputController = new InputController();
            InputController.On();
            FlashLightController = new FlashLightController(InputController);
            PlayerController = InitPlayerController();
            PlayerController.On();
            SelectionController = new SelectionController(InputController);
            SelectionController.On();

            _controllers = new IUpdate[3];
            _controllers[0] = InputController;
            _controllers[1] = FlashLightController;
            _controllers[2] = PlayerController;
            


        }
        private void Update()
        {
            for (int i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].OnUpdate();
            }            
        }

        private PlayerController InitPlayerController()
        {
            PlayerMoveModel playerMoveModel = FindObjectOfType<PlayerMoveModel>();
            CharacterController charController = playerMoveModel.gameObject.AddComponent<CharacterController>();
            Camera head = FindObjectOfType<Camera>();
            IMove playerMovementController = new PlayerMoveController(charController, playerMoveModel, head, InputController);
            return new PlayerController(playerMovementController);
        }
    }
}

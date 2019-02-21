using UnityEngine;
using Game.Interfaces;
using Game.Data;
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
        /// Ссылка на контроллер оружия
        /// </summary>
        public WeaponController WeaponController { get; private set; }
        /// <summary>
        /// Ссылка на главную камеру
        /// </summary>
        private Camera _mainCamera;
        public Camera MainCamera => _mainCamera;

        public DatatController DataController { get; private set; }


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

            _mainCamera = FindObjectOfType<Camera>();
            LoadControllers();
            LoadGameData();

        }
        private void Update()
        {
            for (int i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].OnUpdate();
            }            
        }

        void LoadControllers()
        {
            
            InputController = new InputController();
            InputController.On();
            FlashLightController = new FlashLightController(InputController);
            //FlashLightController.On();
            PlayerController = new PlayerController(new PlayerMoveController(_mainCamera, InputController));
            PlayerController.On();
            SelectionController = new SelectionController(InputController);
            SelectionController.On();
            WeaponController = new WeaponController(InputController);
            WeaponController.On();
            DataController = new DatatController(InputController);
            DataController.On(); 

            _controllers = new IUpdate[4];
            _controllers[0] = InputController;
            _controllers[1] = FlashLightController;
            _controllers[2] = PlayerController;
            _controllers[3] = WeaponController;
        }

        void LoadGameData()
        {
            DataController.Load();
        }

    }
}

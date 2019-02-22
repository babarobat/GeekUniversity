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
        private void Start()
        {
            InputController.On();
            FlashLightController.On();
            PlayerController.On();
            SelectionController.On();
            WeaponController.On();
            DataController.On();
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
            FlashLightController = new FlashLightController(InputController);
            PlayerController = new PlayerController(new PlayerMoveController(_mainCamera, InputController));
            SelectionController = new SelectionController(InputController);
            WeaponController = new WeaponController(InputController);
            DataController = new DatatController(InputController);

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

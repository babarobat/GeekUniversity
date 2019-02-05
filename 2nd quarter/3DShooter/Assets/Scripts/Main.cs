using UnityEngine;
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
        public InputController GetInputController { get; private set; }
        //public InputController GetInputController { get; private set; }
        /// <summary>
        /// Ссылка на контроллер фонарика
        /// </summary>
        public FlashLightController GetFlashLightController { get; private set; }
        /// <summary>
        /// Ссылка на контроллер управления игроком
        /// </summary>
        public PlayerController GetPlayerController { get; private set; }
        /// <summary>
        /// Ссылка на контроллер выбора игроком обьектов на сцене
        /// </summary>
        public SelectionController GetSelectionController { get; private set; }

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
            GetInputController = new InputController();
            GetInputController.On();
            GetFlashLightController = new FlashLightController();
            GetPlayerController = new PlayerController();
            GetPlayerController.On();
            GetSelectionController = new SelectionController();
            GetSelectionController.On();

            _controllers = new IUpdate[3];
            _controllers[0] = GetInputController;
            _controllers[1] = GetFlashLightController;
            _controllers[2] = GetPlayerController;
            


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

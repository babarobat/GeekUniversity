using UnityEngine;
namespace Game
{
    class Main:SingltonMono<Main>
    {
        public InputController GetInputController { get; private set; }
        
        public FlashLightController GetFlashLightController { get; private set; }
        public PlayerController GetPlayerController { get; private set; }
        public SelectionController GetSelectionController { get; private set; }


        private BaseController[] _controllers;
        protected override void Awake()
        {
            base.Awake();
            GetInputController = new InputController();
            GetInputController.On();
            GetFlashLightController = new FlashLightController();
            GetPlayerController = new PlayerController(new UnitMotor(FindObjectOfType<CharacterController>().transform));
            GetPlayerController.On();
            GetSelectionController = new SelectionController();
            GetSelectionController.On();
            _controllers = new BaseController[4];
            _controllers[0] = GetInputController;
            _controllers[1] = GetFlashLightController;
            _controllers[2] = GetPlayerController;
            _controllers[3] = GetSelectionController;


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

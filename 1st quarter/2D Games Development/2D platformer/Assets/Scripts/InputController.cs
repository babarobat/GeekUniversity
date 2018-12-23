using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Класс для получения ввода пользователя
    /// </summary>
    class InputController : Singleton<InputController>
    {
        /// <summary>
        /// Параметры ввода
        /// </summary>
        public ControlParams ControlParams { get; private set; }
        protected override void Awake()
        {
            ControlParams = new ControlParams();

        }
        private void Update()
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            ControlParams.Horizontal = Input.GetAxisRaw("Horizontal");
            ControlParams.Jump = Input.GetAxisRaw("Jump") > 0;
            ControlParams.Fire = Input.GetAxisRaw("Fire1") > 0;
            ControlParams.Interacting = Input.GetKeyDown(KeyCode.E);
#endif


        }
        public void SetHor(float value)
        {
            ControlParams.Horizontal = value;
            

        }
        public void SetFire(bool value)
        {
            ControlParams.Fire = value;
            
        }
        public void SetJump(bool value)
        {
            ControlParams.Jump = value;
            
        }
        public void SetInteracting(bool value)
        {
            ControlParams.Interacting = value;
            

        }
        public void UP()
        {
            print(222);
        }
    }
}

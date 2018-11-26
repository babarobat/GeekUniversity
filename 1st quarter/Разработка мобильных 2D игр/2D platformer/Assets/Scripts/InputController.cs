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
        private void Awake()
        {
            ControlParams = new ControlParams();
            
            
        }
        private void Update()
        {
            ControlParams.Horizontal = Input.GetAxisRaw("Horizontal");
            ControlParams.Jump = Input.GetAxisRaw("Jump")>0;
            ControlParams.Fire = Input.GetAxisRaw("Fire1")>0;

        }
    }
}

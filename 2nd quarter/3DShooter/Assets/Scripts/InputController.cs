using UnityEngine;
using System;
namespace Game
{
    public class InputController : BaseController
    {
        private KeyCode _codeFlashLight = KeyCode.F;
        private int _leftMouseButton = 0;

        public event Action FPressed;
        public event Action LMousePressed;

        public override void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_codeFlashLight))
            {
                FPressed?.Invoke();
            }
            else if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                LMousePressed?.Invoke();
            }
        }
        
    }
}

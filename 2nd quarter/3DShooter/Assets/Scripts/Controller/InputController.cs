using UnityEngine;
using System;
namespace Game
{
    public class InputController : BaseController
    {
        private KeyCode _codeFlashLight = KeyCode.F;
        private int _leftMouseButton = 0;

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }

        public event Action FPressed;
        public event Action LMousePressed;


        public override void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_codeFlashLight))
            {
                FPressed?.Invoke();
            }
            if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                LMousePressed?.Invoke();
            }
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Horizontal");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
        }
        
    }
}

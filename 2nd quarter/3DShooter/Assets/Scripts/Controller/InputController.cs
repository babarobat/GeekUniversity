using UnityEngine;
using System;
using Game.Interfaces;
namespace Game
{
    /// <summary>
    /// Параметры пользовательского ввода
    /// </summary>
    public class InputController : BaseController,IUpdate,IInput
    {
        /// <summary>
        /// Событие нажатия на кнопку E
        /// </summary>
        public event Action OnEnterract;
        
        public event Action OnLeftMouseDown;
        public event Action OnFlashLight;

        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnFlashLight?.Invoke();
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                OnLeftMouseDown?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnEnterract?.Invoke();
            }
            
            
        }
        

        public float GetHorizontal()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public float GetVertical()
        {
            return Input.GetAxisRaw("Vertical");
        }

        public float GetMosueX()
        {
            return Input.GetAxis("Mouse X");
        }

        public float GetMosueY()
        {
            return Input.GetAxis("Mouse Y");
        }
        public bool GetJump()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}

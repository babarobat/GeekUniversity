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
        /// <summary>
        /// Событие нажатия на левую кнопку мыши
        /// </summary>
        public event Action OnLeftMouseDown;
        /// <summary>
        /// Событие нажатия на кнопку F
        /// </summary>
        public event Action OnFlashLight;
        /// <summary>
        /// Событие нажатия на кнопку R
        /// </summary>
        public event Action OnReload;

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
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnReload?.Invoke();
            }
        }

        /// <summary>
        /// значение по оси Horizontal
        /// </summary>
        public float GetHorizontal()
        {
            return Input.GetAxisRaw("Horizontal");
        }
        /// <summary>
        /// значение по оси Vertical
        /// </summary>
        public float GetVertical()
        {
            return Input.GetAxisRaw("Vertical");
        }
        /// <summary>
        /// значение по оси Mouse X
        /// </summary>
        public float GetMosueX()
        {
            return Input.GetAxis("Mouse X");
        }
        /// <summary>
        /// значение по оси Mouse Y
        /// </summary>
        public float GetMosueY()
        {
            return Input.GetAxis("Mouse Y");
        }
        /// <summary>
        /// Нажат пробел?
        /// </summary>
        public bool GetJump()
        {
            return Input.GetKey(KeyCode.Space);
        }
        /// <summary>
        /// Значение вращения колеса мыши
        /// </summary>
        public float GetScrollWheel()
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }
    }
}

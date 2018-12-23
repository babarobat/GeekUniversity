using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// логика и параметры базового компонента
    /// </summary>
    public abstract class  BaseComponentController:MonoBehaviour
    {
        /// <summary>
        /// Ссылка на _characterController;
        /// </summary>
        protected BaseCharacterController _characterController;
        protected virtual void Start()
        {
            _characterController = GetComponentInParent<BaseCharacterController>();
        }
        /// <summary>
        /// Включение/отключение компонента
        /// </summary>
        public bool IsActive
        {
            get => enabled;
            set => enabled = (value);
        }
    }
}

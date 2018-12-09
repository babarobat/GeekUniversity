using UnityEngine;
using System;

namespace Game.Controllers
{
    /// <summary>
    /// Базовый класс для управленя персонажами
    /// </summary>
    public abstract class BaseCharacterController:MonoBehaviour
    {

        /// <summary>
        /// Скорость передвижения
        /// </summary>
        [Tooltip("Скорость передвижения")]
        [SerializeField] protected float _speed;
        /// <summary>
        /// Скорость передвижения
        /// </summary>
        public float Speed => _speed;
        
        /// <summary>
        /// Ссылка на компонент управления движениями
        /// </summary>
        protected MovementController _movementController;
        /// <summary>
        /// Ссылка на компонент управления анимацией
        /// </summary>
        protected AnimationController _animationController;
        protected ControllerEventArgs _controllerEventArgs;
        public event Action<ControllerEventArgs> Move;
        public event Action<ControllerEventArgs> Jump;
        public event Action<ControllerEventArgs> Fire;


        //public Action<float> Move;

        protected virtual void Start()
        {
            _controllerEventArgs = new ControllerEventArgs();
            _movementController = GetComponent<MovementController>() ?? gameObject.AddComponent<MovementController>();
            _animationController = GetComponentInChildren<AnimationController>() ?? GetComponentInChildren<Animator>().gameObject.AddComponent<AnimationController>();
        }
    }
}

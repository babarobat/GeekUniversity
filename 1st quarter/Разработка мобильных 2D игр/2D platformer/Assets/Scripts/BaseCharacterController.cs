using UnityEngine;
using System;

namespace Game.Controllers
{
    /// <summary>
    /// Базовый класс для управленя персонажами
    /// </summary>
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MovementController))]
    public abstract class BaseCharacterController : MonoBehaviour
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
        protected Animator _animator;



        //public Action<float> Move;

        protected virtual void Start()
        {
            _movementController = GetComponent<MovementController>();
            _animator = GetComponent<Animator>();
        }
    }
}
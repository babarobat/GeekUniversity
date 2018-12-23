using UnityEngine;

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
        /// Текущая скорость передвижения
        /// </summary>
        public float Speed
        {
            get => _currentSpeed;
            set => _currentSpeed = value;
        }
        protected float _currentSpeed;
        /// <summary>
        /// Ссылка на компонент управления движениями
        /// </summary>
        protected MovementController _movementController;
        /// <summary>
        /// Ссылка на аниматор
        /// </summary>
        protected Animator _animator;
        

        protected virtual void Start()
        {
            _movementController = GetComponentInChildren<MovementController>();
            _animator = GetComponentInChildren<Animator>();
            _currentSpeed = _speed;
        }
        /// <summary>
        /// логика смерти персонажа
        /// </summary>
        protected virtual void Dead()
        {
            print(name + " Dead");
        }
    }
}
using System;
using UnityEngine;
using Game.Controllers;
using UnityEngine.SceneManagement;

namespace Game {
    /// <summary>
    /// Содержит логику и параметры управления персонажем
    /// </summary>
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(AnimationController))]
    [RequireComponent(typeof(WeaponController))]
    public class PlayerController : BaseCharacterController,IDamage
    {

        /// <summary>
        /// Сила прыжка
        /// </summary>
        [Tooltip("Сила прыжка")] [SerializeField] private float _jumpForce = 600;
        /// <summary>
        /// Слой, с которого можно прыгать
        /// </summary>
        [Tooltip("название слоя, с которого можно прыгать")] [SerializeField] private LayerMask _whatIsGround;
        /// <summary>
        /// Трансформ для определения нахождения на земле
        /// </summary>
        [Tooltip("Трансформ для определения нахождения на земле")] [SerializeField] private Transform _groundCheck;
        /// <summary>
        /// Здоровье персонажа
        /// </summary>
        [Tooltip("Здоровье персонажа")] [SerializeField] private int _hp;

        /// <summary>
        /// Персонаж находится на земле?
        /// </summary>
        private bool isGrounded;
        /// <summary>
        /// Радиус проверки на нахождение на земле
        /// </summary>
        private const float groundedRadius = .2f;

        /// <summary>
        /// Ссылка на движущуюся часть карты
        /// </summary>
        [SerializeField] private Transform _map;
        /// <summary>
        /// Событие для 
        /// </summary>
        public Action<int> HpChanged;
        
        /// <summary>
        /// Здоровье персонажа
        /// </summary>
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value < 0 ? 0 : value;
                HpChanged?.Invoke(_hp);
            }
        }
        /// <summary>
        /// Параметры управления
        /// </summary>
        [SerializeField] private ControlParams _controlParams;
        /// <summary>
        /// Ссылка на компонент управления оружием
        /// </summary>
        private WeaponController _weaponController;
        

        

        protected override void Start()
        {
            
            base.Start();
            
            
            _weaponController = GetComponentInChildren<WeaponController>();
            _controlParams = InputController.Instance.ControlParams;


        }
        void Update()
        {
            //Движение заднего фона карты. Прототип
            _map.Translate(Vector2.right * -_controlParams.Horizontal * .3f * Time.deltaTime);
            //Move?.Invoke(_speed * _controlParams.Horizontal);
            Move();
            Jump();
            Fire();
        }
        private void FixedUpdate()
        {
            ChekCanJump();
        }
        /// <summary>
        /// Движение персонажа
        /// </summary>
        public void Move()
        {
            _animationController.Move(_controlParams.Horizontal);
            _movementController.Move(_speed * _controlParams.Horizontal);
        }
        /// <summary>
        /// Прыжок
        /// </summary>
        public void Jump()
        {
            if (_controlParams.Jump && isGrounded)
            {
                isGrounded = false;
                _animationController.Jump();
                _movementController.Jump(_jumpForce);
            }
        }
        /// <summary>
        /// Можно ли прыгать?
        /// </summary>
        private void ChekCanJump()
        {
            Collider2D[] collidrs = Physics2D.OverlapCircleAll(_groundCheck.position, groundedRadius, _whatIsGround);
            foreach (var col in collidrs)
            {
                if (col.gameObject != gameObject)
                {

                    isGrounded = true;
                    _animationController.Grounded();
                }
            }
        }
        /// <summary>
        /// Стрельба
        /// </summary>
        public void Fire()
        {
            if (_controlParams.Fire)
            {
                _weaponController.Fire();
                
            }
        }
        /// <summary>
        /// Поученить урон
        /// </summary>
        /// <param name="damage">колличество урона</param>
        public void GetDamage(int damage)
        {
            Hp -= damage;
            Debug.Log("Объект " + name + " получил " + damage + " урона. Осталось " + Hp + " жизней");

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Spikes")
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
}
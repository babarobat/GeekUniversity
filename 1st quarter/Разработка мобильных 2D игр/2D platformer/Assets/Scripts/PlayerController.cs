using System;
using UnityEngine;
using Game.Controllers;
using UnityEngine.SceneManagement;

namespace Game
{
    /// <summary>
    /// Содержит логику и параметры управления персонажем
    /// </summary>
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    [RequireComponent(typeof(HealthController))]
    public class PlayerController : BaseCharacterController
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
        
        /// <summary>
        /// Параметры управления
        /// </summary>
        [SerializeField] private ControlParams _controlParams;
        /// <summary>
        /// Ссылка на компонент управления оружием
        /// </summary>
        private WeaponController _weaponController;
        private HealthController _Hp;

        private bool _isControllable = true;


        public void  IsControllable(bool value)
        {
            switch (value)
            {
                case true:
                    _isControllable = true;
                    GetComponent<Rigidbody2D>().simulated = true;
                    _Hp.IsActive = true;
                        break;
                case false:
                    _Hp.IsActive = false;
                    GetComponent<Rigidbody2D>().simulated = false;
                    _isControllable = false;
                   
                    break;
               
            }
        }

        protected override void Start()
        {

            base.Start();
            _Hp = GetComponentInChildren<HealthController>();
            _weaponController = GetComponentInChildren<WeaponController>();
            _controlParams = InputController.Instance.ControlParams;
            _Hp.HpIsZero += Dead;

            
            

        }
        void Update()
        {
            

            if (_isControllable)
            {
                //Движение заднего фона карты. Прототип
                _map.Translate(Vector2.right * -_controlParams.Horizontal * .3f * Time.deltaTime);


                //Move();
                //Jump();
                //Fire();
            }
            
        }
        private void FixedUpdate()
        {
            ChekCanJump();
            Move();
            Jump();
            Fire();
        }
        /// <summary>
        /// Движение персонажа
        /// </summary>
        public void Move()
        {
            _animator.SetFloat("VelocityX", Mathf.Abs( _controlParams.Horizontal));
            _movementController.Move(_controlParams.Horizontal * Speed*Time.fixedDeltaTime);
        }
        /// <summary>
        /// Прыжок
        /// </summary>
        public void Jump()
        {
            if (_controlParams.Jump && isGrounded)
            {
                isGrounded = false;
                _animator.SetBool("IsJumping", true);
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
                    _animator.SetBool("IsJumping", false);
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
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Spikes")
            {
                (_Hp as IDamage).GetDamage(100);
            }
        }
        public void ResetParams()
        {
            _Hp.ResetParams();
        }
        protected override void Dead()
        {
            base.Dead();
            LoadManager.Instance.LoadFromChekPoint();
            _Hp.ResetParams();

        }
    }
}
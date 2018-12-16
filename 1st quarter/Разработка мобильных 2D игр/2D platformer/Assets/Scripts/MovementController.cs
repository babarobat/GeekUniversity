using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Содержит логику и параметры управления движение персонажа
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class MovementController : BaseComponentController
    {

        /// <summary>
        /// Ссылка на компонет RigidBody2D
        /// </summary>
        private Rigidbody2D _rb;
        protected override void Start()
        {
            base.Start();
            _rb = GetComponentInParent<Rigidbody2D>();
            //GetComponent<BaseCharacterController>().Move += Move;

        }
        /// <summary>
        /// Двигает персонажа с заданной скоростью.
        /// Направление движения зависит от скорости:
        /// при отрицательном значении скорости персонаж будет двигаться влево.
        /// </summary>
        /// <param name="moveSpeed">Скорость движения</param>
        public void Move(float moveSpeed)
        {
            _rb.velocity = new Vector2(moveSpeed * Time.deltaTime, _rb.velocity.y);
            transform.rotation = GetRotation();
        }
        /// <summary>
        /// Заставляет прыгнуть персонажа с заданной силой прыжка
        /// </summary>
        /// <param name="jumpForce">Сила прыжка</param>
        public void Jump(float jumpForce)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        /// <summary>
        /// Двигает персонажа к заданной позиции с заданной скоростью
        /// </summary>
        /// <param name="target">позиция цели</param>
        /// <param name="speed">скорость</param>
        public void MoveToTarget(Vector2 target, float speed)
        {
            Vector2 dir = (target - (Vector2)transform.position).normalized;
            _rb.velocity = dir * speed * Time.deltaTime;

            transform.rotation = GetRotation();
        }
        public void Stop()
        {
            
            _rb.velocity = Vector2.zero;
        }
        private Quaternion GetRotation()
        {
            var rotationY = _rb.velocity.x < 0 ? 180 : _rb.velocity.x > 0 ? 0 : transform.rotation.eulerAngles.y;
            return Quaternion.Euler(0, rotationY, 0);
        }
        public void LookAtTarget(Transform target)
        {
            var targetOnRight = transform.position.x < target.position.x ? false : true;
            var rotationY = targetOnRight ? 180 :  0 ;
            transform.rotation =  Quaternion.Euler(0, rotationY, 0);
        }
        
        
    }
}
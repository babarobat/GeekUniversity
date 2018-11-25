using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Содержит логику и параметры управления движение персонажа
    /// </summary>
    public class MovementController : BaseComponentController
    {
        /// <summary>
        /// Ссылка на компонет RigidBody2D
        /// </summary>
        private Rigidbody2D _rb;
        private void Start()
        {
            _rb = GetComponentInParent<Rigidbody2D>();
        }
        /// <summary>
        /// Двигает персонажа с заданной скоростью по заданному направлению по оси X
        /// </summary>
        /// <param name="moveSpeed">Скорость движения</param>
        /// <param name="horizontal">направление движения</param>
        public void Move(float moveSpeed)
        {
            _rb.velocity = new Vector2(moveSpeed * Time.deltaTime, _rb.velocity.y);
            transform.localScale = moveSpeed < 0 ? new Vector3(-1, 1, 1):
                                   moveSpeed > 0 ? new Vector3(1, 1, 1) : transform.localScale;
        }
        /// <summary>
        /// Заставляет прыгнуть персонажа с заданной силой прыжка
        /// </summary>
        /// <param name="jumpForce">Сила прыжка</param>
        public void Jump(float jumpForce)
        {

            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector3.up * jumpForce);

        }
        public void MoveTo(Transform target,float  speed)
        {
            _rb.velocity = target.position.x < transform.position.x ? new Vector2(-speed * Time.deltaTime, _rb.velocity.y) : new Vector2(speed * Time.deltaTime, _rb.velocity.y);
            transform.localScale = _rb.velocity.x < 0 ? new Vector3(-1, 1, 1) :
                                   _rb.velocity.x > 0 ? new Vector3(1, 1, 1) : transform.localScale;
        }
    }
}

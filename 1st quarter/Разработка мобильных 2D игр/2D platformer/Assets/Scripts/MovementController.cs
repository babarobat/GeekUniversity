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
        private Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponentInParent<Rigidbody2D>();
        }
        /// <summary>
        /// Двигает персонажа с заданной скоростью по заданному направлению по оси X
        /// </summary>
        /// <param name="moveSpeed">Скорость движения</param>
        /// <param name="horizontal">направление движения</param>
        public void Move(float moveSpeed, float horizontal)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
            //_map.Translate(Vector2.right * -hor * .3f * Time.deltaTime);
            transform.localScale = horizontal < 0 ? new Vector3(-1, 1, 1):
                                   horizontal > 0 ? new Vector3(1, 1, 1) : transform.localScale;
        }
        /// <summary>
        /// Заставляет прыгнуть персонажа с заданной силой прыжка
        /// </summary>
        /// <param name="jumpForce">Сила прыжка</param>
        public void Jump(float jumpForce)
        {

            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector3.up * jumpForce);

        }
    }
}

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
            

        }
        /// <summary>
        /// Двигает персонажа с заданной скоростью.
        /// Направление движения зависит от скорости:
        /// при отрицательном значении скорости персонаж будет двигаться влево.
        /// </summary>
        /// <param name="moveSpeed">Скорость движения</param>
        public void Move(float moveSpeed)
        {
            _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
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
        
        public void JumpTo(Vector3 end, float deg)
        {
            _rb.velocity = Vector2.zero;
            Vector3  start = transform.position;

            //Вычисляем расстояние до точки, куда нам нужно попасть
            float distance = Vector3.Distance(start, end);

            //Вычисляем направление, сиё есть вектор
            var direction = (end - start).normalized;
            direction.y= 1/Mathf.Sin((2 * deg) * Mathf.Deg2Rad); 
            direction.x /= 2;
            print(direction);
            


            //Наконец-то вычисляем силу, по-хорошему надо бы использовать Physics.gravity, но я 
            //воспользовался константой = 9.81f
            //F = m * SQRT(distance * g) * direction/ sin (2a); 
            var force = _rb.mass* Mathf.Sqrt(distance * Physics2D.gravity.magnitude) * direction ;
            
            //Швыряем!
            _rb.AddForce(force,ForceMode2D.Impulse);
        }
        /// <summary>
        /// Двигает персонажа к заданной позиции с заданной скоростью поворачивая лицом в по направлению движения
        /// </summary>
        /// <param name="target">позиция цели</param>
        /// <param name="speed">скорость</param>
        public void MoveToTarget(Vector2 target, float speed)
        {
            Vector2 dir = (target - (Vector2)transform.position).normalized;
            _rb.velocity = dir * speed ;

            transform.rotation = GetRotation();
        }
        public void MoveToTarget(Vector2 target, float speed, Transform lookAt)
        {
            Vector2 dir = (target - (Vector2)transform.position).normalized;
            _rb.velocity = dir * speed;
            LookAtTarget(lookAt);


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
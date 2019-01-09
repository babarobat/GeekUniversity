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
            //Vector2 startPos = transform.position;
            //Vector2 targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
            var radAngle = deg * Mathf.Deg2Rad;
            var dir = (end - transform.position).normalized;
            float x = (end - transform.position).magnitude;
            float y = (end - transform.position).y;

            float v2 = (Physics2D.gravity.magnitude * x * x) / (2 * (y - Mathf.Tan(radAngle) * x) * Mathf.Pow(Mathf.Cos(radAngle), 2));
            float v = Mathf.Sqrt(Mathf.Abs(v2));

            _rb.velocity = new Vector2(Mathf.Cos(radAngle) * v * dir.x, Mathf.Sin(radAngle) * v);
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
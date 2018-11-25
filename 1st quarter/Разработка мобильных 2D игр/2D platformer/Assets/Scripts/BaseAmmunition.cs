using UnityEngine;


namespace Game
{
    /// <summary>
    /// Базовая логика и параметры аммуниции
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseAmmunition:MonoBehaviour
    {
        /// <summary>
        /// Скорость полета снаряда
        /// </summary>
        public float Speed { get; set; }
        /// <summary>
        /// Урон 
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// Ссылка на твердое тело данного обьекта
        /// </summary>
        private Rigidbody2D _rb;
        /// <summary>
        /// Время до уничтожения обьекта
        /// </summary>
        private const float lifeTime = 5f;
        protected void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = Vector3.right * Speed;
            Destroy(gameObject, lifeTime);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<IDamage>()?.GetDamage(2);
            Destroy(gameObject);
        }

    }
   
}

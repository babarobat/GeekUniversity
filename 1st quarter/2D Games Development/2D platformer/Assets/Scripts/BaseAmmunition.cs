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
        /// <summary>
        /// Префаб эффект попадания
        /// </summary>
        [SerializeField]       
        private GameObject _hitEffect;
        /// <summary>
        /// Направление движения снаряда
        /// </summary>
        public Vector2 Dir;

        protected void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = Dir * Speed;
            Destroy(gameObject, lifeTime);
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponentInChildren<IDamage>()?.GetDamage(Damage);
            if (_hitEffect != null)
            {
                var temp = Instantiate(_hitEffect, transform.position, Quaternion.identity);
                Vector2 pos = transform.position;
                Destroy(temp, 2);
            }
            Destroy(gameObject);

        }
        

    }
   
}

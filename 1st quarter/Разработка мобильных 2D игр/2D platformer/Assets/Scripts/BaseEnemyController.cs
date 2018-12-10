using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Логика и параметры базового вражеского юнита
    /// </summary>
    class BaseEnemyController:BaseCharacterController,IDamage
    {
        /// <summary>
        /// Начальное здоровье
        /// </summary>
        [Tooltip("Начальное здоровье")]
        [SerializeField] protected float _startHp;
        /// <summary>
        /// Урон, который наносится при столкновении с персонажем
        /// </summary>
        [Tooltip("Урон, который наносится при столкновении с персонажем")]
        [SerializeField] protected int _damage;
        /// <summary>
        /// Координаты начала RayCast
        /// </summary>
        [Tooltip("Координаты начала RayCast")]
        [SerializeField] protected Transform _rayCastPoint;
        public float CurrentHp
        {
            get => _currentHp; 
            set
            {
                _currentHp = value < 0 ? 0 : value;
                if (_currentHp == 0)
                {
                    Explode();
                    Destroy(gameObject);
                }
            }
        }
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        protected float _currentHp;
        /// <summary>
        /// Текущая скорость
        /// </summary>
        protected float _currentSpeed;
        /// <summary>
        /// Цель
        /// </summary>
        protected Transform _target;

        /// <summary>
        /// Ссылка на компенент ExplosionController;
        /// </summary>
        protected ExplosionController _explosionController;


        [SerializeField]
        protected Transform[] _patrolPoints;
        protected int _patrolPointIndex = 0;





        protected override void Start()
        {
            base.Start();
            _explosionController = GetComponentInChildren<ExplosionController>();
            CurrentHp = _startHp;
            
        }
        /// <summary>
        /// Логика получения урона
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(int damage)
        {
            CurrentHp -= damage;
            Debug.Log("Объект "+name+" получил "+damage+ " урона. Осталось "+CurrentHp+" жизней" );
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<IDamage>()?.GetDamage(_damage);           
        }
        private void Explode()
        {
            _animationController.IsActive = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
            _explosionController?.Explode();
            
        }
        
    }
}

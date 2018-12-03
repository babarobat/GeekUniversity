using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Логика и параметры базового вражеского юнита
    /// </summary>
    class BaseEnemyController:BaseCharacterController,IDamage
    {
        

        /// <summary>
        /// Радиус агро
        /// </summary>
        [Tooltip("Радиус агро")]
        [SerializeField] protected float _agroRadius;
        /// <summary>
        /// Скорость преследования
        /// </summary>
        [Tooltip("Скорость преследования")]
        [SerializeField] protected float _followSpeed;
        /// <summary>
        /// Координаты точек патрулирования
        /// </summary>
        [Tooltip("Координаты точек патрулирования")]
        [SerializeField] protected Transform[] _patrolPoints;
        /// <summary>
        /// Начальное здоровье
        /// </summary>
        [Tooltip("Начальное здоровье")]
        [SerializeField] protected float _startHp;
        /// <summary>
        /// Урон
        /// </summary>
        [Tooltip("Урон")]
        [SerializeField] protected int _damage;
        /// <summary>
        /// Координаты начала RayCast
        /// </summary>
        [Tooltip("Координаты начала RayCast")]
        [SerializeField] protected Transform _rayCastPoint;
        public float CurrentHp
        {
            get
            {
                return _currentHp;
            }

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
        /// RayCast для определения цели
        /// </summary>
        protected RaycastHit2D _hit;
        /// <summary>
        /// Координаты цели
        /// </summary>
        protected Vector2 _targetPos;
        /// <summary>
        /// Текущая скорость
        /// </summary>
        protected float _currentSpeed;
        /// <summary>
        /// Цель
        /// </summary>
        protected Transform _target;
        /// <summary>
        /// Индекс текущей точки патрулирования
        /// </summary>
        protected int patrolPointIndex = 0;


        protected ExplosionController _explosionController;

        protected override void Start()
        {
            base.Start();
            _explosionController = GetComponentInChildren<ExplosionController>();
            _hit = new RaycastHit2D();
            CurrentHp = _startHp;
            _target = FindObjectOfType<PlayerController>().transform;
            _targetPos = new Vector2();
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
            _explosionController.Explode();
            
        }
    }
}

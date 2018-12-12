using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Логика и параметры базового вражеского юнита
    /// </summary>
    class BaseEnemyController:BaseCharacterController
    {
        /// <summary>
        /// Урон, который наносится при столкновении с персонажем
        /// </summary>
        [Tooltip("Урон, который наносится при столкновении с персонажем")]
        [SerializeField] protected int _damage;
        
        /// <summary>
        /// Цель
        /// </summary>
        protected Transform _target;

        /// <summary>
        /// Ссылка на компенент ExplosionController;
        /// </summary>
        protected ExplosionController _explosionController;
        /// <summary>
        /// Точки для патрулирования
        /// </summary>
        [Tooltip("Точки для патрулирования")]
        [SerializeField]
        protected Transform[] _patrolPoints;
        /// <summary>
        /// текущий индекс точки патрулирваня
        /// </summary>
        protected int _patrolPointIndex = 0;
        /// <summary>
        /// Ссылка на зрение
        /// </summary>
        protected FieldOfViewController _fow;
        /// <summary>
        /// Ссылка на здоровье
        /// </summary>
        protected HealthController _hp;
        protected override void Start()
        {
            base.Start();
            _target = FindObjectOfType<PlayerController>().transform;
            _fow = GetComponentInChildren<FieldOfViewController>();
            _explosionController = GetComponentInChildren<ExplosionController>();
            _hp = GetComponentInChildren<HealthController>();
            
            _hp.HpIsZero += Dead;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponentInChildren<IDamage>()?.GetDamage(_damage);           
        }
          
    }
}

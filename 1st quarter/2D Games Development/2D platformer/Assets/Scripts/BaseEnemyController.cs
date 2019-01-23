using UnityEngine;
using System.Collections;

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
        protected PlayerController _target;
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
            _target = FindObjectOfType<PlayerController>();
            _fow = GetComponentInChildren<FieldOfViewController>();
            _explosionController = GetComponentInChildren<ExplosionController>();
            _hp = GetComponentInChildren<HealthController>();
            _hp.HpIsZero += Dead;
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            var iDamage = collision.gameObject.GetComponentInChildren<IDamage>();
            if (iDamage != null)
            {
                iDamage?.GetDamage(_damage);
                var thisLayer = gameObject.layer;
                var collLayer = collision.gameObject.layer;
                StartCoroutine(IgnoreLayerForSec(1f, thisLayer, collLayer));               
            }    
        }
        /// <summary>
        /// Выключает коллизии на указанный промежуток времени между указанными слоями
        /// </summary>
        /// <param name="time">время игнорирования коллизий</param>
        /// <param name="id1">id слоя 1</param>
        /// <param name="id2">id слоя 2</param>
        /// <returns></returns>
        IEnumerator IgnoreLayerForSec(float time, int id1, int id2)
        {
            Physics2D.IgnoreLayerCollision(id1, id2, true);
            yield return new WaitForSeconds(time);
            Physics2D.IgnoreLayerCollision(id1, id2, false);
        }

          
    }
}

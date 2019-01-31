using UnityEngine;
using System;

namespace Game
{
    /// <summary>
    /// Базавая логика и параметры оружия
    /// </summary>
    public abstract class BaseWeapon:MonoBehaviour
    {
        /// <summary>
        /// Активно ли оружие
        /// </summary>
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }
        /// <summary>
        /// Урон 
        /// </summary>
        [Tooltip("Урон ")]
        [SerializeField] protected int _damage;
        /// <summary>
        /// Скорость снарядов
        /// </summary>
        [Tooltip("Скорость снарядов")]
        [SerializeField] protected float _ammoSpeed;
        /// <summary>
        /// Скорострельбенность
        /// </summary>
        [Tooltip("Скорострельбенность")]
        [SerializeField] protected float _fireSpeed;
        /// <summary>
        /// Место появления снаряда
        /// </summary>
        [Tooltip("Место появления снаряда")]
        [SerializeField] protected Transform _firePosint;
        /// <summary>
        /// Префаб снаряда
        /// </summary>
        [Tooltip("Префаб снаряда")]
        [SerializeField] protected BaseAmmunition _ammunitionPrefab;
        /// <summary>
        /// Время последнего выстрела
        /// </summary>
        protected DateTime _lastShotTime;
        /// <summary>
        /// Может ли оружие стрелять
        /// </summary>
        
        
        public bool CanFire
        {
            get => (DateTime.Now - _lastShotTime).Milliseconds > _fireSpeed*1000;
        }
        
        protected virtual void Start()
        {
            _lastShotTime = DateTime.Now;//.AddMilliseconds(-_fireSpeed*1000);
            
        }

        /// <summary>
        /// Выстреливает заданным снарядом в заданном направлении
        /// </summary>
        /// <param name="dir">направление стрельбы</param>
        public virtual void Fire()
        {            
            if (CanFire)
            {
                
                var dir = transform.rotation.eulerAngles.y == 180 ? -Vector2.right : Vector2.right;
                _lastShotTime = DateTime.Now;
                var proj = Instantiate(_ammunitionPrefab, _firePosint.position, transform.rotation);
                proj.Speed = _ammoSpeed;
                proj.Damage = _damage;
                proj.Dir = dir;
                
                
            }
        }
        
        
    }
}

using UnityEngine;
using System;
using System.Collections;
namespace Game
{
    /// <summary>
    /// Базовое оружие
    /// </summary>
    public abstract class BaseWeapon:BaseObjectScene
    {
        [SerializeField]
        protected WeaponType _type;
        /// <summary>
        /// Точка стрельбы
        /// </summary>
        [SerializeField]
        protected Transform _firePoint;
        /// <summary>
        /// Время перезарядки
        /// </summary>
        [SerializeField]
        protected float _reloadTime;
        /// <summary>
        /// Время между выстрелами
        /// </summary>
        [SerializeField]
        protected float _fireRate;
        /// <summary>
        /// Урон
        /// </summary>
        [SerializeField]
        protected float _damage;
        /// <summary>
        /// Максимальное колличество обойм
        /// </summary>
        [SerializeField]
        protected int _maxClipCount;
        /// <summary>
        /// текущее колличество обойм
        /// </summary>
        protected int _currentClipCount;
        /// <summary>
        /// Максимальное колличество патронов в обойме
        /// </summary>
        [SerializeField]
        protected int _maxBulletsInClip;
        /// <summary>
        /// текущее колличество патронов в обойме
        /// </summary>
        protected int _currentBulletsInClip;
        /// <summary>
        /// информация об уроне
        /// </summary>
        protected DamageInfo _damageInfo;
        /// <summary>
        /// Максимальное колличество обойм
        /// </summary>
        public int MaxClipCount => _maxClipCount;
        /// <summary>
        /// текущее колличество обойм
        /// </summary>
        public int CurrentClipCount => _currentClipCount;
        /// <summary>
        /// Максимальное колличество патронов в обойме
        /// </summary>
        public int MaxBulletsInClip => _maxBulletsInClip;
        /// <summary>
        /// текущее колличество патронов в обойме
        /// </summary>
        public int CurrenBulletsInClip => _currentBulletsInClip;
        /// <summary>
        /// оружие может стрелять?
        /// </summary>
        protected bool _canFire;
        /// <summary>
        /// оружие может стрелять?
        /// </summary>
        public bool CanFire => _canFire;
        /// <summary>
        /// оружее выбрано?
        /// </summary>
        private bool _selected;
        /// <summary>
        /// оружее выбрано?
        /// </summary>
        public bool Selected
        { get => _selected;
          set
            {
                if (value ==true)
                {
                    CallOnAmmoChange();
                }
                _selected = value;
                _canFire = value;
                IsVisible = value;
            }
        }
        /// <summary>
        /// Событие изменения колличества патронов и обойм
        /// </summary>
        public static Action<int, int, int, int, string> OnAmmoChange;
        /// <summary>
        /// Событие окончания патронов
        /// </summary>
        public static Action NoClips;
        /// <summary>
        /// Событие окончания обойм
        /// </summary>
        public static Action NoBullets;
        /// <summary>
        /// Событие перезарядки
        /// </summary>
        public static Action OnReload;
        protected override void Awake()
        {
            base.Awake();
            _damageInfo = new DamageInfo();
            _damageInfo.Type = _type;
            _currentClipCount = _maxClipCount;
            _currentBulletsInClip = _maxBulletsInClip;
            if (Selected)
            {
                CallOnAmmoChange();
            }
        }
        /// <summary>
        /// Выстрелить
        /// </summary>
        public abstract void Fire();
        /// <summary>
        /// Перезарядка
        /// </summary>
        public void Reload()
        {
             StartCoroutine(ReloadCor());
        }

        /// <summary>
        /// Вызывает событие отсутсвия патронов
        /// </summary>
        protected void CallNoBullets()
        {
            NoBullets?.Invoke();
        }
        /// <summary>
        /// Событие отсутствия обойм
        /// </summary>
        protected void CallNoClips()
        {
            NoClips?.Invoke();
        }
        /// <summary>
        /// вызывает событие перезарядки
        /// </summary>
        protected void CallOnReload()
        {
            OnReload?.Invoke();
        }
        /// <summary>
        /// Вызывает Событие изменения колличества патронов и обойм
        /// </summary>
        protected void CallOnAmmoChange()
        {
            OnAmmoChange?.Invoke(CurrenBulletsInClip, MaxBulletsInClip, CurrentClipCount, MaxClipCount, name);
        }
        IEnumerator ReloadCor()
        {
            
            
            if (CurrentClipCount > 0&& CurrenBulletsInClip != MaxBulletsInClip)
            {
                _canFire = false;
                OnReload?.Invoke();
                yield return new WaitForSeconds(_reloadTime);
                _canFire = true;
                _currentClipCount--;
                _currentBulletsInClip = MaxBulletsInClip;
                CallOnAmmoChange();
            }
            if (CurrentClipCount <=0)
            {
                _canFire = false;
                NoClips?.Invoke();
                yield return new WaitForSeconds(_fireRate);
                _canFire = true;
            }
            
            
            
        }
        
    }
}

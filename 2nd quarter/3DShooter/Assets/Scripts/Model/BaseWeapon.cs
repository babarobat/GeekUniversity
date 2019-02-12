using UnityEngine;
using System;
using System.Collections;
namespace Game
{
    public abstract class BaseWeapon:BaseObjectScene
    {
        
        [SerializeField]
        protected Transform _firePoint;
        [SerializeField]
        protected float _reloadTime;
        [SerializeField]
        protected float _fireRate;
        [SerializeField]
        protected float _damage;
        [SerializeField]
        protected int _maxClipCount;
        protected int _currentClipCount;
        [SerializeField]
        protected int _maxBulletsInClip;
        protected int _currentBulletsInClip;
        protected DamageInfo _damageInfo;
        

        
        public int MaxClipCount => _maxClipCount;
        public int CurrentClipCount => _currentClipCount;
        public int MaxBulletsInClip => _maxBulletsInClip;
        public int CurrenBulletsInClip => _currentBulletsInClip;
               
        
        protected bool _canFire;
        public bool CanFire => _canFire;
        private bool _selected;
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
        
        protected override void Awake()
        {
            base.Awake();
            _damageInfo = new DamageInfo(_damage);
            _currentClipCount = _maxClipCount;
            _currentBulletsInClip = _maxBulletsInClip;
            if (Selected)
            {
                CallOnAmmoChange();
            }
        }
        public abstract void Fire();
        public void Reload()
        {
            
               StartCoroutine(ReloadCor());
            
        }
        public static Action<int, int, int, int, string> OnAmmoChange;
        public static Action NoClips;
        public static Action NoBullets;

        public static Action OnReload;

        protected void CallNoBullets()
        {
            NoBullets?.Invoke();
        }
        protected void CallNoClips()
        {
            NoClips?.Invoke();
        }
        protected void CallOnReload()
        {
            OnReload?.Invoke();
        }

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

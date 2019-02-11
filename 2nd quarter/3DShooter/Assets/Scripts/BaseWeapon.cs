using UnityEngine;

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
       
        protected int _maxBulletsInClip;
        protected Clip _clip;
        protected bool _canFire;
        private bool _selected;
        public bool Selected
        { get => _selected;
          set
            {
                _canFire = value;
                IsVisible = value;
            }
        }
        
        protected override void Awake()
        {
            base.Awake();
            _clip = new Clip(_maxBulletsInClip);
        }
        public abstract void Fire();
        
    }
}

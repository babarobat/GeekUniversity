using UnityEngine;

namespace Game
{
    public abstract class BaseWeapon:BaseObjectScene
    {
        [SerializeField]
        protected float _fireRate;
        [SerializeField]
        protected float _damage;
        [SerializeField]
        protected int _maxClipCount;
        protected int _currentClipCount;
        [SerializeField]
        protected int _maxBulletsInClip;
        protected Clip _clip;
        protected bool _canFire;
        public bool Selected;
        protected Transform _firePoint;
        protected override void Awake()
        {
            base.Awake();
            _clip = new Clip(_maxBulletsInClip);
        }
        public abstract void Fire();
        
    }
}

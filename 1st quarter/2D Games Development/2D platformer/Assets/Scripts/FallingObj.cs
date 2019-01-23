using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    class FallingObj:MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _renderer;
        [SerializeField]       
        int _damage;
        [SerializeField]
        GameObject _hitEffect;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponentInChildren<SpriteRenderer>();
            //Destroy(gameObject,2);
        }
        
        public Sprite Sprite
        {
            set => _renderer.sprite = value;
        }
        public int Damage
        {
            get => _damage;
            set => _damage = value < 0 ? 0 : value;
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

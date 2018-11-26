using UnityEngine;

namespace Game.Controllers
{
    class BaseEnemyController:BaseCharacterController,IDamage
    {
        [SerializeField] protected float _agroRadius;
        [SerializeField] protected float _followSpeed;
        [SerializeField] protected Transform[] _patrolPoints;
        [SerializeField] protected float _hp;
        [SerializeField] protected int _damage;
        public float Hp
        {
            get => _hp;
            set
            {
                _hp = value < 0 ? 0 : value;
            }
        }

        protected Transform _target;
        protected bool _isMad;
        
        protected int patrolPointIndex = 0;
        protected override void Start()
        {
            base.Start();
            _target = FindObjectOfType<PlayerController>().transform;
        }
        private void OnDrawGizmosSelected()
        {
            //Gizmos.DrawWireSphere(transform.position, _agroRadius);
            Gizmos.DrawLine(transform.position, transform.position+Vector3.right);
        }

        public void GetDamage(int damage)
        {
            Hp -= damage;
            Debug.Log("Объект "+name+" получил "+damage+ " урона. Осталось "+Hp+" жизней" );
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            collision.gameObject.GetComponent<IDamage>()?.GetDamage(_damage);
            
        }
    }
}

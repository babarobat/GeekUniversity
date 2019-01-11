using System.Collections;
using UnityEngine;

namespace Game.Controllers
{
    class Boss : BaseEnemyController
    {
        private BossState _currentSate = BossState.Sleeping;
        [SerializeField]
        Trigger _activasionTrigger;
        public float _distTiGround;
        public LayerMask ground;
        bool _moveForward = true;
        float? _movePointX;
        bool _move = true;
        bool _skill = false;
        bool _canJump = true;
        int _actionIndex;
        [SerializeField]
        float minPosX;
        [SerializeField]
        float maxPosX;
        CameraController _cam;

        bool _grounded;
        protected override void Start()
        {
            base.Start();
            _cam = FindObjectOfType<CameraController>();
            _activasionTrigger.OnEnter += ActivateBoss;
            _hp.OnHpChange += OnHpChange;
            
        }
        private void FixedUpdate()
        {
            
            //_grounded = Physics2D.Raycast(transform.position, Vector2.down, _distTiGround, ground);
            print(_grounded);
        }
        private void Update()
        {
            if (_currentSate != BossState.Sleeping)
            {
                Xxx();
            }

        }
        IEnumerator Activate()
        {
            yield return new WaitForSeconds(1);
            _currentSate = BossState.One;
        }
        void ActivateBoss(TriggerEventArgs e)
        {
            StartCoroutine(Activate());
        }
        void OnHpChange(int value)
        {
            _currentSate = value > (_hp.StartHp / 3) * 2 ? BossState.One : value > (_hp.StartHp / 3) ? BossState.Two : BossState.Three;

        }
        void Move()
        {

            if (_movePointX == null)
            {
                var dirX = GetRandomExcept(0, -1, 2) * Random.Range(5, 10);
                //var randomPoint = (int)Random.Range(_target.transform.position.x, _target.transform.position.x + 10);
                _movePointX = _target.transform.position.x < transform.position.x ? transform.position.x + dirX :// :
                                                                                    transform.position.x - dirX; //* dirX;
                _movePointX = Mathf.Clamp((float)_movePointX, minPosX, maxPosX);
                
                var animName = dirX > 0 ? "MoveBack" : "Move";
                _animator.SetTrigger(animName);
            }
            else
            {
                if (Mathf.Abs((float)_movePointX - transform.position.x) > 1f)
                {
                    var movePos = new Vector2((float)_movePointX, transform.position.y);
                    _movementController.MoveToTarget(movePos, _speed * Time.deltaTime, _target.transform);
                }
                else
                {
                    _actionChoosed = false;
                    _movementController.Stop();
                    _movePointX = null;
                }
            }
        }
        public BaseAmmunition _wavePrefab;
        public Transform waveLspawnPoint;
        public Transform waveRspawnPoint;


        
        void Jump()
        {
            
            if (_canJump)
            {
                _animator.SetTrigger("Jump");
                switch (_currentSate)
                {
                    case BossState.One:
                        _movementController.Jump(25);
                        break;
                    case BossState.Two:
                        _movementController.JumpTo(_target.transform.position, 75);
                        break;
                }
                _grounded = false;
                _canJump = false;
            }
            //bool grounded = Physics2D.Raycast(transform.position, Vector2.down, _distTiGround, ground);

            if (_grounded)
            {
                _movementController.Stop();
                SpawnWave(waveLspawnPoint, 1, 10);
                SpawnWave(waveRspawnPoint, 1, 10);

                _canJump = true;
                _actionChoosed = false;
                
            }
        }
        void SpawnWave( Transform posAddRot, int dmg, float speed)
        {
            var wave = Instantiate(_wavePrefab, posAddRot.position, posAddRot.rotation);
            wave.Damage = dmg;
            wave.Dir = posAddRot.eulerAngles.y == 180 ? -Vector2.right : Vector2.right;
            wave.Speed = speed;
            _cam?.ShakeCam(wave.gameObject);

        }
        IEnumerator Idle()
        {
            _animator.SetTrigger("Idle");
            yield return new WaitForSeconds(1);
            _actionChoosed = false;
            idle = false;
        }

        bool _actionChoosed = false;
        bool idle = false;
        int lastIndex;


        void Xxx()
        {
            if (!_actionChoosed)
            {
                _actionIndex = GetRandomExcept(lastIndex, 1, 4);
                lastIndex = _actionIndex;
                _actionChoosed = true;

            }
            switch (_actionIndex)
            {
                case 1:

                    Move();
                    break;
                case 2:

                    Jump();
                    break;
                case 3:

                    if (!idle)
                    {

                        StartCoroutine(Idle());
                        idle = true;
                    }
                    break;
            }
        }
        int GetRandomExcept(int exception, int min, int max)
        {
            var r = Random.Range(min, max);
            return r == exception ? GetRandomExcept(exception, min, max) : r;

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (collision.transform.CompareTag("Ground"))
            {
                _grounded = true;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                _grounded = false;
            }
        }
        
    }
}

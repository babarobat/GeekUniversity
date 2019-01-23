using System.Collections;
using System;
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

        public event Action DropBricks;
        private Vector2 _startPos;
        bool _grounded;
        protected override void Start()
        {
            base.Start();
            _cam = FindObjectOfType<CameraController>();
            _activasionTrigger.OnEnter += ActivateBoss;
            _hp.OnHpChange += OnHpChange;
            _startPos = transform.position;
            _target.OnPlayerDead += ResetBoss;


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
            _movementController.LookAtTarget(_target.transform);
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
                //var dist = Mathf.Abs( transform.position.x - _target.transform.position.x);
                float dirX = UnityEngine.Random.Range(5, 10);
                //bool targetIsRighter = _target.transform.position.x > transform.position.x;
               // bool targetIsOutOfRange = dist > 5f;


                //var randomPoint = (int)Random.Range(_target.transform.position.x, _target.transform.position.x + 10);

                

                _movePointX = _target.transform.position.x < transform.position.x ? transform.position.x - dirX :// :
                                                                                    transform.position.x + dirX; //* dirX;
                _movePointX = Mathf.Clamp((float)_movePointX, minPosX, maxPosX);
                
                //var animName = dirX < 0 ? "MoveBack" : "Move";
                _animator.SetTrigger("Move");
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
        [Range(0, 50)]
        public float JumpForce;

        
        void Jump()
        {
            
            if (_canJump)
            {
                _animator.SetTrigger("Jump");
                switch (_currentSate)
                {
                    case BossState.One:
                        _movementController.Jump(JumpForce);

                        
                        break;
                    case BossState.Two:
                        _movementController.Jump(JumpForce);
                        break;
                    case BossState.Three:
                        var targetOnRight = transform.position.x < _target.transform.position.x;

                        if (((transform.position.x<=  minPosX + 5) && (!targetOnRight)) ||
                                (( transform.position.x  >= maxPosX-5 )&&(targetOnRight)))
                        {
                            _movementController.Jump(25);
                        }
                        else
                        {
                            var dir = transform.position.x < _target.transform.position.x ? 1 : -1;
                            _movementController.JumpOnAngle(7, new Vector2(dir, 4));
                            
                        }
                        
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
                _cam?.ShakeCam(gameObject);

            }
        }
        void SpawnWave( Transform posAndRot, int dmg, float speed)
        {
            var wave = Instantiate(_wavePrefab, posAndRot.position, posAndRot.rotation);
            wave.Damage = dmg;
            wave.Dir = posAndRot.eulerAngles.y == 180 ? -Vector2.right : Vector2.right;
            wave.Speed = speed;
            

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
                if (Mathf.Abs(transform.position.x - _target.transform.position.x)>15)
                {
                    _actionIndex = 1;
                }
                else
                {
                    _actionIndex = GetRandomExcept(lastIndex, 1, 4);
                    lastIndex = _actionIndex;
                    _actionChoosed = true;
                }
                

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
            var r = UnityEngine.Random.Range(min, max);
            return r == exception ? GetRandomExcept(exception, min, max) : r;

        }
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            if (collision.transform.CompareTag("Ground"))
            {
                _grounded = true;
                if (_currentSate == BossState.Two || _currentSate == BossState.Three)
                {
                    DropBricks?.Invoke();
                }
               
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                _grounded = false;
            }
        }

        private void ResetBoss()
        {
            _hp.ResetParams();
            _currentSate = BossState.Sleeping;
            transform.position = _startPos;
            _movementController.Stop();
            _animator.SetTrigger("Idle");
        }
        
    }
}

﻿using System.Collections;
using System;
using UnityEngine;
using Game.Audio;

namespace Game.Controllers
{
    /// <summary>
    /// Содержит параметры и логику босса
    /// </summary>
    class Boss : BaseEnemyController
    {
        /// <summary>
        /// Текущая фаза босса
        /// </summary>
        private BossState _currentState = BossState.Sleeping;
        public BossState State => _currentState;

        /// <summary>
        /// Ссылка на тригер, активирующий босса
        /// </summary>
        [SerializeField]
        Trigger _activasionTrigger;
        /// <summary>
        /// расстояния от Tramsform босса до земли
        /// </summary>
        public float _distTiGround;
        /// <summary>
        /// Макска земли
        /// </summary>
        public LayerMask ground;
        /// <summary>
        /// Позиция для двежения
        /// </summary>
        float? _movePointX;
        /// <summary>
        /// Может ли босс прыгать?
        /// </summary>
        bool _canJump = true;
        /// <summary>
        /// Индек действия
        /// </summary>
        int _actionIndex;
        /// <summary>
        /// Миримальная точка для движения по Х 
        /// </summary>
        [SerializeField]
        float minPosX;
        /// <summary>
        /// Мксимальная точка для движения по Х 
        /// </summary>
        [SerializeField]
        float maxPosX;
        /// <summary>
        /// Ссылка на камера контроллер
        /// </summary>
        CameraController _cam;
        /// <summary>
        /// Босс приземлился
        /// </summary>
        public event Action<GameObject> Grounded;
        /// <summary>
        /// Начальая позиция босса
        /// </summary>
        private Vector2 _startPos;
        /// <summary>
        /// Босс стоит на земле?
        /// </summary>
        bool _grounded;

        /// <summary>
        /// минимум для получения случайной точки движения
        /// </summary>
        private const int movementXMin = 5;
        /// <summary>
        /// Максимум для получения случайной точки движения
        /// </summary>
        private const int movementXMax = 10;
        /// <summary>
        /// урон волны
        /// </summary>
        private const int waveDmg = 1;
        /// <summary>
        /// скорость волны
        /// </summary>
        private const float waveSpeed = 10;
        /// <summary>
        /// Длительность бездействия босса
        /// </summary>
        private const float idleTime = 1f;
        /// <summary>
        /// Выбрано ли следующее действие
        /// </summary>
        private bool _actionChoosed = false;
        /// <summary>
        /// Босс бездействует?
        /// </summary>
        private bool _idle = false;
        /// <summary>
        /// Индекс последнего действия
        /// </summary>
        private int _lastIndex;
        /// <summary>
        /// Префаб волны
        /// </summary>
        public BaseAmmunition _wavePrefab;
        /// <summary>
        /// Место спаунаволны слева от босса
        /// </summary>
        public Transform waveLspawnPoint;
        /// <summary>
        /// Место спаунаволны справа от босса
        /// </summary>
        public Transform waveRspawnPoint;
        /// <summary>
        /// Сила прыжка босса
        /// </summary>
        [Range(0, 50)]
        public float JumpForce;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        private SoundComponent _stepsSound;
        [SerializeField]
        private SoundComponent _movementSound;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        private SoundComponent _GroundedSound;
        protected override void Start()
        {
            base.Start();
            _cam = FindObjectOfType<CameraController>();
           
            _activasionTrigger.OnEnter += ActivateBoss;
            _hp.OnHpChange += ChangeStateBecauseHP;
            _startPos = transform.position;
            _target.OnPlayerDead += ResetBoss;
            OnBossDead += FindObjectOfType<LoadManager>().EndGame;

        }
        private void FixedUpdate()
        {
            print(_currentState);
            if (_currentState != BossState.Sleeping)
            {
                MainActions();
            }
        }
        
        [SerializeField]
        private float _activateTime;
        /// <summary>
        /// Запускает алгоритм активации босса
        /// </summary>
        /// <returns></returns>
        IEnumerator Activate()
        {
            _movementController.LookAtTarget(_target.transform);
            GlobalGameManager.Instance.ChangeState(GameStates.GameBoss);
            yield return new WaitForSeconds(_activateTime);
            _wall.SetActive(false);
            _currentState = BossState.One;
            
        }
        /// <summary>
        /// Активирует босса
        /// </summary>
        /// <param name="e"></param>
        void ActivateBoss(TriggerEventArgs e)
        {
            StartCoroutine(Activate());
        }
        /// <summary>
        /// Меняет фазу в зависимости от колличества хп босса
        /// </summary>
        /// <param name="value"></param>
        void ChangeStateBecauseHP(int value)
        {
            if (value < _hp.StartHp*2 / 3 && _currentState == BossState.One)
            {
                StartCoroutine(ChangeState(4));
            }
            if (value < _hp.StartHp * 1 / 3 && _currentState == BossState.Two)
            {
                StartCoroutine(ChangeState(4));
            }

            //}

            //_currentSate = value > (_hp.StartHp / 3) * 2 ? BossState.One : value > (_hp.StartHp / 3) ? BossState.Two : BossState.Three;
        }

        
        /// <summary>
        /// Двигает босса в зависимости от позиции игрока.
        /// </summary>
        void Move()
        {
            if (_movePointX == null)
            {
                float dirX = UnityEngine.Random.Range(movementXMin, movementXMax);
                _movePointX = _target.transform.position.x < transform.position.x ? transform.position.x - dirX :
                                                                                    transform.position.x + dirX;
                _movePointX = Mathf.Clamp((float)_movePointX, minPosX, maxPosX);
                
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
       
        /// <summary>
        /// Заставляет босса прыгнуть в зависимости от текуще фазы босса. После преземления запускает волны по обе стороны от босса
        /// </summary>
        void Jump()
        {            
            if (_canJump)
            {
                _animator.SetTrigger("Jump");
                switch (_currentState)
                {
                    case BossState.One:
                        _movementController.Jump(JumpForce);
                        break;
                    case BossState.Two:
                        _movementController.Jump(JumpForce);
                        break;
                    case BossState.Three:
                        var targetOnRight = transform.position.x < _target.transform.position.x;
                        if (((transform.position.x<=  minPosX + 7) && (!targetOnRight)) ||
                                (( transform.position.x  >= maxPosX-7 )&&(targetOnRight)))
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
            if (_grounded)
            {
                _movementController.Stop();
                SpawnWave(waveLspawnPoint, waveDmg, waveSpeed);
                SpawnWave(waveRspawnPoint, waveDmg, waveSpeed);

                _canJump = true;
                _actionChoosed = false;
                _cam.ShakeCam(gameObject);

            }
        }
        /// <summary>
        /// Создает волну в заданном месте и присваивает ей параметры
        /// </summary>
        /// <param name="posAndRot">позиция и вращение волны</param>
        /// <param name="dmg">урон</param>
        /// <param name="speed">скорость</param>
        void SpawnWave( Transform posAndRot, int dmg, float speed)
        {
            var wave = Instantiate(_wavePrefab, posAndRot.position, posAndRot.rotation);
            wave.Damage = dmg;
            wave.Dir = posAndRot.eulerAngles.y == 180 ? -Vector2.right : Vector2.right;
            wave.Speed = speed;
        }
        /// <summary>
        /// Запускает фазу бездействия босса
        /// </summary>
        /// <returns></returns>
        IEnumerator Idle()
        {
            _animator.SetTrigger("Idle");
            yield return new WaitForSeconds(idleTime);
            _actionChoosed = false;
            _idle = false;
        }
        

        /// <summary>
        /// Рандомно выбирает, а затем запускает алгоритм выполнения действия: двигаться, прыгнуть, бездействовать.
        /// Два действия в подряд не могут быть выбраны
        /// </summary>
        void MainActions()
        {
            if (!_actionChoosed)
            {
                if (Mathf.Abs(transform.position.x - _target.transform.position.x)>15)
                {
                    _actionIndex = 1;
                }
                else
                {
                    _actionIndex = Extensions.GetRandomExcept( 1, 4, _lastIndex);
                    _lastIndex = _actionIndex;
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

                    if (!_idle)
                    {
                        StartCoroutine(Idle());
                        _idle = true;
                    }
                    break;
            }
        }
        
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            if (collision.transform.CompareTag("Ground"))
            {
                _grounded = true;
                _GroundedSound.Play("FX_RobotGrounded");
                Grounded?.Invoke(gameObject);
                              
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                _grounded = false;
            }
        }
        [SerializeField]
        protected GameObject _wall;
        /// <summary>
        /// Возвращает босса в стартовое положение
        /// </summary>
        public void ResetBoss()
        {
            StopAllCoroutines();
            GlobalGameManager.Instance.CurrentState = GameStates.GameNormal;
            _hp.ResetParams();
            _currentState = BossState.Sleeping;
            transform.position = _startPos;
            _movementController.Stop();
            _animator.SetTrigger("Idle");
            _wall.transform.position = transform.position;
            _wall.SetActive(true);
            _grounded = true;
        }
        public void PlaySteps()
        {
            _stepsSound.PlayRandomSound();
        }
        public void PlayMove()
        {
            _movementSound.PlayRandomSound();
        }
        IEnumerator ChangeState( float time)
        {
            _wall.transform.position = transform.position;
            _wall.SetActive(true);
            _animator.SetTrigger("Idle");
            _movePointX = null;
            BossState previousState = _currentState;
            _currentState = BossState.Sleeping;
            
           yield return new WaitForSeconds(time);
            _wall.SetActive(false);
            switch (previousState)
            {
                
                case BossState.One:
                    _currentState = BossState.Two;   
                    break;
                case BossState.Two:
                    _currentState = BossState.Three;
                    break;
                
            }

        }
        public Action OnBossDead;
        protected override void Dead()
        {
            base.Dead();
            OnBossDead?.Invoke();
        }


    }
}

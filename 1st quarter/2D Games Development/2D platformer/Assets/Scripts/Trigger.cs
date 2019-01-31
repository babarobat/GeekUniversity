using System;
using System.Linq;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    class Trigger : MonoBehaviour
    {
        [SerializeField]
        private TriggerEventArgs _args;
        public TriggerEventArgs Args => _args;
        [SerializeField]
        private string[] _triggerActivatorsTegs;
        [SerializeField]
        bool _disableAfterInterract;
        [SerializeField]
        bool _disableAfterEnter;
        [SerializeField]
        bool _disableAfterExit;
        [SerializeField]
        bool _activateAfterPlayerDead;
        public bool IsInteractble;
        public event Action<TriggerEventArgs> OnStay;
        public event Action<TriggerEventArgs> OnEnter;
        public event Action<TriggerEventArgs> OnExit;
        public event Action<TriggerEventArgs> OnInteract;


        //Animator _animator;
        
        private void Start()
        {
            _args.Sender = this;
            GetComponent<Collider2D>().isTrigger = true;
            //_animator = GetComponentInChildren<Animator>();
            if (_activateAfterPlayerDead)
            {
                FindObjectOfType<PlayerController>().OnPlayerDead += Activate;
            }
        }

        void Activate()
        {
            foreach (var item in GetComponents<Collider2D>())
            {
                item.enabled = true;
            }
        }
        void Deactivate()
        {
            foreach (var item in GetComponents<Collider2D>())
            {
                item.enabled = false;

            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_triggerActivatorsTegs.Contains(collision.tag))
            {
                
                OnStay?.Invoke(_args);
                if (Controllers.InputController.Instance.ControlParams.Interacting)    
                {
                    OnInteract?.Invoke(_args);
                    //if (IsInteractble)
                    //{
                    //    //_args.boolMeta = !_args.boolMeta;
                    //    //_animator?.SetBool("On", _args.boolMeta);
                    //}
                    if (_disableAfterInterract)
                    {
                        Deactivate();
                    }
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_triggerActivatorsTegs.Contains(collision.tag))
            {
                
                OnEnter?.Invoke(_args);
                if (_disableAfterEnter)
                {
                    Deactivate();
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_triggerActivatorsTegs.Contains(collision.tag))
            {
                OnExit?.Invoke(_args);
                if (_disableAfterEnter)
                {
                    Deactivate();
                }
            }
        }

        
    }
}

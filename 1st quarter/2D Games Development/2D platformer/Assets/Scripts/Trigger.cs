﻿using System;
using System.Linq;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    class Trigger : MonoBehaviour
    {
        [SerializeField]
        private TriggerEventArgs _args;
        
        [SerializeField]
        private string[] _triggerActivatorsTegs;
        [SerializeField]
        bool _disableAfterInterract;
        [SerializeField]
        bool _disableAfterEnter;
        [SerializeField]
        bool _disableAfterExit;
        [SerializeField]
        
        public bool IsInteractble;
         

        public event Action<TriggerEventArgs> OnStay;
        public event Action<TriggerEventArgs> OnEnter;
        public event Action<TriggerEventArgs> OnExit;
        public event Action<TriggerEventArgs> OnInteract;


        Animator _animator;
        public bool IsEnable
        {
            get => GetComponent<Collider2D>().enabled;
            set => GetComponent<Collider2D>().enabled = value;
        }
        private void Start()
        {
            _args.Sender = this;
            GetComponent<Collider2D>().isTrigger = true;
            _animator = GetComponentInChildren<Animator>();
        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_triggerActivatorsTegs.Contains(collision.tag))
            {
                OnStay?.Invoke(_args);
                if (Controllers.InputController.Instance.ControlParams.Interacting
                    && _triggerActivatorsTegs.Contains(collision.tag)
                    && IsInteractble)
                {
                    _args.boolMeta = !_args.boolMeta;
                    _animator?.SetBool("On", _args.boolMeta);
                    OnInteract?.Invoke(_args);

                    if (_disableAfterInterract)
                    {
                        IsEnable = false;
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
                    IsEnable = false;
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
                    IsEnable = false;
                }
            }
        }
    }
}
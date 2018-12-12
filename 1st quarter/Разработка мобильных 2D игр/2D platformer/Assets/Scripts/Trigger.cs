using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    class Trigger : MonoBehaviour
    {
        [SerializeField]
        private TriggerEventArgs _args;
        [SerializeField]
        private ITriggersListner[] _listners;
        [SerializeField]
        private string[] _triggerActivatorsTegs;
        [SerializeField]
        bool _disableAfterInterract;
        [SerializeField]
        bool _disableAfterEnter;
        [SerializeField]
        bool _disableAfterExit;

         

        public event Action<TriggerEventArgs> OnStay;
        public event Action<TriggerEventArgs> OnEnter;
        public event Action<TriggerEventArgs> OnExit;
        public event Action<TriggerEventArgs> OnInteract;
        public bool IsEnable
        {
            get => enabled;
            set => enabled = value;
        }
        private void Start()
        {
            _args.Sender = this;
            GetComponent<Collider2D>().isTrigger = true;
        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            OnStay?.Invoke(_args);
            if (Controllers.InputController.Instance.ControlParams.Interacting && _triggerActivatorsTegs.Contains(collision.tag))
            {
                _args.boolMeta = !_args.boolMeta;
                OnInteract?.Invoke(_args);

                if (_disableAfterInterract)
                {
                    IsEnable = false;
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

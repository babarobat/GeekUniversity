using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Controllers
{
    public abstract class  BaseComponentController:MonoBehaviour
    {
        protected BaseCharacterController _characterController;
        protected virtual void Start()
        {
            _characterController = GetComponentInParent<BaseCharacterController>();
        }
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Controllers
{
    class InputController : Singleton<InputController>
    {
        public ControlParams ControlParams { get; private set; }
        private void Start()
        {
            ControlParams = new ControlParams();
        }
        private void Update()
        {
            ControlParams.Horizontal = Input.GetAxisRaw("Horizontal");
            ControlParams.Jump = Input.GetAxisRaw("Jump")>0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Controllers
{
    class AnimationController : BaseComponentController
    {
        private Rigidbody2D rb;
        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            rb = GetComponentInParent<Rigidbody2D>();
        }
        public override void Action(ControlParams e)
        {
            _animator.SetFloat("VelocityX", Mathf.Abs(e.Horizontal));
            if (e.Jump)
            {
                _animator.SetTrigger("Jump");

            }
            if (e.Grounded)
            {
                _animator.SetTrigger("Grounded");
            }
        }
    }
}

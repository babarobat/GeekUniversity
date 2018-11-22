using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Controllers
{
    class MovementController : BaseComponentController
    {
        Rigidbody2D rb;
        public float speed = 10;
        public float jumpForce = 30;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _map;
        
        private bool isGrounded;
        private const float groundedRadius = .2f;
        private Vector3 velocity = Vector3.zero;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
        }
        public override void Action(ControlParams e)
        {
            
            Move(speed, e.Horizontal);
            Jump(e.Jump);
        }
        public void Move(float moveSpeed, float horizontal)
        {
            var hor = horizontal;
            var speed = moveSpeed;

            rb.velocity = new Vector2(hor * speed * Time.deltaTime, rb.velocity.y);
            //_map.Translate(Vector2.right * -hor * .3f * Time.deltaTime);
            transform.localScale = hor < 0 ? new Vector3(-1, 1, 1) : hor > 0 ? new Vector3(1, 1, 1) : transform.localScale;
        }
        private void FixedUpdate()
        {
            
            Collider2D[] collidrs = Physics2D.OverlapCircleAll(_groundCheck.position, groundedRadius, _whatIsGround);
            foreach (var col in collidrs)
            {
                if (col.gameObject != gameObject)
                {
                    isGrounded = true;
                    //_animator.SetTrigger("Grounded");
                }
            }
        }
        private void Jump(bool jump)
        {
            if (jump && isGrounded)
            {
                Debug.Log("1");
                isGrounded = false;
                //_animator.SetTrigger("Jump");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }
}

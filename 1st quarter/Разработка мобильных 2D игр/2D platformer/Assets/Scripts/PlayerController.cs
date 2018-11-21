using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public float jumpForce = 30;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;

    private bool isGrounded;    
    private const float groundedRadius = .2f;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    private Animator _animator;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] collidrs = Physics2D.OverlapCircleAll(_groundCheck.position, groundedRadius, _whatIsGround);
        foreach (var col in collidrs)
        {
            if (col.gameObject != gameObject)
            {
                isGrounded = true;
                _animator.SetTrigger("Grounded");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var jump = Input.GetAxisRaw("Jump") > 0;
        
        rb.velocity = new Vector2(hor * speed * Time.deltaTime, rb.velocity.y);
        transform.localScale = hor < 0 ? new Vector3(-1, 1, 1) : hor > 0 ? new Vector3(1, 1, 1) : transform.localScale;


        _animator.SetFloat("VelocityX",Mathf.Abs( hor));
        
        if (jump && isGrounded)
        {
            _animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector3.up * jumpForce);
        }

    }
}

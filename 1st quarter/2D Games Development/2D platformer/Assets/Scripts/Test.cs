using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class Test:MonoBehaviour
    {
        bool x = false;
        Rigidbody2D rb;
        public
        Camera cam;
        [Range(1,89)]
        public float angle;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
        }

        //F = m * SQRT(distance * g) * direction/ sin (2a);
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                
                Vector2 targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
                
                //Vector2 dir = (targetPos - (Vector2)transform.position).normalized;
                //dir.y = 1/Mathf.Sin((2 * angle) * Mathf.Rad2Deg);
                //dir.x /= 1/Mathf.Cos((2 * angle) * Mathf.Rad2Deg);

                
                var dist =Vector2.Distance(transform.position ,cam.ScreenToWorldPoint(Input.mousePosition));
                //print("dsit " + dist);
                
                rb.velocity = 
            }
        }
    }
}

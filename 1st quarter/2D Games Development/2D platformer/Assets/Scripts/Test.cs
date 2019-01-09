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
        float g ;
       
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(1, 1);
            g = Physics2D.gravity.magnitude;
            
        }

        
        private void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                
                Vector2 startPos = transform.position;
                Vector2 targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
                var radAngle = angle * Mathf.Deg2Rad;
                var dir = (targetPos - startPos).normalized;
                float x = (targetPos - startPos).magnitude;
                float y = (targetPos - startPos).y;

                float v2 = (g * x * x) / (2 * (y - Mathf.Tan(radAngle) * x) * Mathf.Pow(Mathf.Cos(radAngle), 2));
                float v = Mathf.Sqrt(Mathf.Abs(v2));

                rb.velocity = new Vector2(Mathf.Cos(radAngle) * v* dir.x, Mathf.Sin(radAngle) * v) ;

            }
        }
    }
}

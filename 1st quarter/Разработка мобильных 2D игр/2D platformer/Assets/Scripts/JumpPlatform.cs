using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    class JumpPlatform:MonoBehaviour
    {
        public float force;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force, ForceMode2D.Impulse);
        }
    }
}

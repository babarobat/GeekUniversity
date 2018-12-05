using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    class FieldOfViewController:BaseComponentController
    {
        
        public float _viewRadious;
       
        [Range(0,360)]
        public float _viewAngle;

        public Vector2 DirFromAngle(float angleDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleDegrees += transform.eulerAngles.y;
            }
            return new Vector2(Mathf.Cos(angleDegrees * Mathf.Deg2Rad), Mathf.Sin(angleDegrees * Mathf.Deg2Rad));
        }
        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.white;
        //    Gizmos.DrawWireSphere(transform.position, _viewRadious);
        //}
    }
}

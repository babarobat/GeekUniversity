using System;
using Game.Interfaces;
using UnityEngine;

namespace Game
{
    class EnemyVision : IVision
    {
        private Transform _target;
        private float _range;
        private float _angle;

        public void SetRange(float value)
        {
            _range = value <= 0 ? 0 : value;
        }
        public void SetAngle(float value)
        {
            _angle = value <= 0 ? 0 : value;
        }
        public EnemyVision(Transform target, float range, float angle)
        {
            _target = target;
            _range = range;
            _angle = angle;
        }
        public Transform GetTarget(Transform self)
        {
            if (TargetInRange(self)&&TarGetInAngle(self)&& !TargetIsBlocked(self))
            {
                return _target.transform;
            }
            else
            {
                return null;
            }
        }
        bool TargetInRange(Transform self)
        {
            return Extensions.InRage(self.position, _target.position, _range);
        }
        bool TarGetInAngle(Transform self)
        {
            Vector3 dir = (_target.position - self.position);
            return Vector3.Angle(self.forward, dir)<=_angle/2;
        }
        bool TargetIsBlocked(Transform self)
        {
            RaycastHit hit;
            if (!Physics.Linecast(self.transform.position, _target.position, out hit))
            {
                return true;
            }
            else
            {
                Debug.DrawLine(self.transform.position, hit.transform.position);
            } 
            return hit.transform != _target;


        }
        
    }
}

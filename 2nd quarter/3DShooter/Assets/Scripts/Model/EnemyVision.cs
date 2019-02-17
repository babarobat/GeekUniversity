using System;
using Game.Interfaces;
using UnityEngine;



namespace Game
{
    class EnemyVision : IVision
    {
        private BaseObjectScene _target;
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
        public EnemyVision(BaseObjectScene target, float range)
        {
            _target = target;
            _range = range;
        }
        public Transform GetTarget(Vector3 self)
        {
            if (Extensions.InRage(self, _target.Transform.position,_range))
            {
                return _target.transform;
            }
            else
            {
                return null;
            }
        }
    }
}

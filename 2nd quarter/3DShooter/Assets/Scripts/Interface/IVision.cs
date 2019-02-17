using UnityEngine;
namespace Game.Interfaces
{
    public interface IVision
    {
        
        Transform GetTarget(Vector3 self);
        void SetRange(float value);
        void SetAngle(float value);
    }
}

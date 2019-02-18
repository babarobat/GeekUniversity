using UnityEngine;
namespace Game.Interfaces
{
    public interface IVision
    {
        
        Transform GetTarget(Transform self);
        void SetRange(float value);
        void SetAngle(float value);
    }
}

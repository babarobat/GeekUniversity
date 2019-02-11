using System;
namespace Game.Interfaces
{
    /// <summary>
    /// Параметры пользовательского ввода
    /// </summary>
    public interface IInput
    {
        float GetHorizontal();
        
        float GetVertical();
        
        float GetMosueX();
        
        float GetMosueY();

        float GetScrollWheel();

        bool GetJump();

        event Action OnEnterract;
        event Action OnLeftMouseDown;
        event Action OnFlashLight;

    }
}

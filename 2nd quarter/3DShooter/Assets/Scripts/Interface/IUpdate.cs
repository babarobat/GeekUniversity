namespace Game
{
    /// <summary>
    /// Поведение обьекта в апдейте
    /// </summary>
    public interface IUpdate
    {
        void OnUpdate();
        void FixedUpdate();
    }
}

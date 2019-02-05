namespace Game
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public abstract class BaseController
    {
        /// <summary>
        /// Включен?
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// Включить
        /// </summary>
        public virtual void On()
        {
            On(null);
        }
        /// <summary>
        /// Включить
        /// </summary>
        /// <param name="obj"></param>
        public virtual void On(BaseObjectScene obj)
        {
            IsActive = true;
        }
        /// <summary>
        /// Выключить
        /// </summary>
        public virtual void Off()
        {
            IsActive = false;
        }
        /// <summary>
        /// Включить если выключен и наоборот
        /// </summary>
        public void Switch()
        {

            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }
        
    }
}

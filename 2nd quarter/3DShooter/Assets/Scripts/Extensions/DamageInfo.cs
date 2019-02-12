namespace Game
{
    /// <summary>
    /// Информация об уроне
    /// </summary>
    public class DamageInfo
    {
        /// <summary>
        /// Колличество урона
        /// </summary>
        public float Damage { get; private set; }
        
        
        public DamageInfo(float damage)
        {
            Damage = damage;
        }
    }
}

namespace Game
{
    /// <summary>
    /// Дает возможность обьекту получить урон
    /// </summary>
    interface IDamage
    {
        /// <summary>
        /// Получить урон
        /// </summary>
        /// <param name="damage">колличество урона</param>
        void GetDamage(int damage);
    }
}

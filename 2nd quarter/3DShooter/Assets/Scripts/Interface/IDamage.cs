
namespace Game.Interfaces
{
    /// <summary>
    /// Логика получения урона
    /// </summary>
    public interface IDamageble
    {
        /// <summary>
        /// Получить урон
        /// </summary>
        /// <param name="damageInfo">Параметры урона</param>
        void GetDamage(DamageInfo damageInfo);
    }
}

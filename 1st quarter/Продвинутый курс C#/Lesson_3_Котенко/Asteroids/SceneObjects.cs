using System.Collections.Generic;

namespace Asteroids
{
    /// <summary>
    /// Содержит списки обьектов сцены по типам
    /// </summary>
    public static class SceneObjects
    {
        /// <summary>
        /// Ссылка на список Астероидов
        /// </summary>
        public static List<BaseObject> Asteroids { get; private set; }
        /// <summary>
        /// Ссылка на список фонов
        /// </summary>
        public static List<BaseObject> BackGrounds { get; private set; }
        /// <summary>
        /// Ссылка на список ракет
        /// </summary>
        public static List<BaseObject> Rockets { get; private set; }
        /// <summary>
        /// Ссылка на коллецкию аптечек
        /// </summary>
        public static List<BaseObject> HealthPacks { get; private set; }
        /// <summary>
        /// Ссылка на игрока
        /// </summary>
        public static Ship Player { get; set; }

        static SceneObjects()
        {
            Asteroids = new List<BaseObject>();
            BackGrounds = new List<BaseObject>();
            Rockets = new List<BaseObject>();
            HealthPacks = new List<BaseObject>();


        }

    }
}

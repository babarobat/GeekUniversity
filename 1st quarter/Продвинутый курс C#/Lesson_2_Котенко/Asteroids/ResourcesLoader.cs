using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Загрузка изображений из ресурсов
    /// </summary>
    public static class ResourcesLoader
    {
        /// <summary>
        /// Список изображений заданного типа
        /// </summary>
        /// <param name="typeOf">Тип обьекта</param>
        /// <returns></returns>
        public static List<string>  GetImage(TypeOf typeOf)
        {
            switch (typeOf)
            {
                case TypeOf.backGround:
                    return new List<string>()
                    {
                     "Resources/Bg_Stars_1.png",
                     "Resources/Bg_Stars_2.png",
                     "Resources/Bg_Stars_3.png"
                    };                    
                case TypeOf.rocket:
                     return new List<string>() { "Resources/SpaceRocket.png" };
                case TypeOf.asteroid:
                    return new List<string>() { "Resources/Asteroid.png" };                    
                case TypeOf.playerShip:
                    return new List<string>() { "" };                   
                case TypeOf.enemy:
                    return new List<string>() { "" };
                default:
                    return null;
            }
        }
    }
}

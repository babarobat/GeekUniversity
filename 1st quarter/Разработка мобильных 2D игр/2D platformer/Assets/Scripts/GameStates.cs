using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public enum GameStates
    {
        MainMenu,
        Pause,
        GameNormal,
        GameFight,
        GameBoss,
        Death
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class COnditionController:Singleton<COnditionController>
    {
        public void ChangeTime(float value)
        {
            Time.timeScale = value < 0 ? 0 : value;
        }
        
    }
}

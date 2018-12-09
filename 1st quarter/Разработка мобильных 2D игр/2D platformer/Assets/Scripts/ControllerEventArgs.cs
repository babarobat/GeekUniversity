using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ControllerEventArgs
    {
        public float Speed { get; set; }
        public bool Jump { get; set; }
        public bool Fire { get; set; }

        public ControllerEventArgs()
        {
            Speed = 0;
            Jump = false;
            Fire = false;
        }
        

    }
}

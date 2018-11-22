using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Controllers
{
    public class ControlParams
    {
        public float Horizontal { get; set; }
        public float MovingSpeed { get; set; }
        public bool Jump { get; set; }
        public bool Grounded { get; set; }

    }
}

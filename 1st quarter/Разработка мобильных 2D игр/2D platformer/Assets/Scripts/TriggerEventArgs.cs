using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    class TriggerEventArgs
    {
        public bool boolMeta;
        public int intMeta;
        public Object Sender;
        public string stringMeta;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    [Serializable]
    class TriggerEventArgs
    {
        public bool boolMeta;
        public int intMeta;
        public Trigger Sender;
        public string stringMeta;
        public Vector3 VectorMeta;

    }
}

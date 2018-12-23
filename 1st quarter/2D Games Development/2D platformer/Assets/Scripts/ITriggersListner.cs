using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ITriggersListner
    {
        void OnInterractWhithTrigger(TriggerEventArgs args);
        void OnLeaveTrigger(TriggerEventArgs args);
        void OnEnterTrigger(TriggerEventArgs args);
    }
}

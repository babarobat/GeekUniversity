using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface  ISelectable
    {
        SelectableItemInfo Info { get; }
         void OnSelected();
    }
}

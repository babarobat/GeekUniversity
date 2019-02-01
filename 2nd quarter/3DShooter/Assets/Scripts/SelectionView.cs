using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class SelectionView:MonoBehaviour
    {
        public void ShowSelectedInfo(SelectableItemInfo info)
        {
            print(info.Info);
        }
    }
}

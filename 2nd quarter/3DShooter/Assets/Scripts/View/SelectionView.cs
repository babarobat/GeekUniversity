using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Логика отображения информации о выделенном обьекте
    /// </summary>
    class SelectionView:MonoBehaviour
    {
        public void ShowSelectedInfo(SelectableItemInfo info)
        {
            print( $"selected item info: {info.Info}");
        }

    }
}

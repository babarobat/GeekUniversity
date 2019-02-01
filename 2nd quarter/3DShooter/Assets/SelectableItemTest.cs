using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class SelectableItemTest : BaseObjectScene, ISelectable
    {
        [SerializeField]
        private SelectableItemInfo _info;
        public SelectableItemInfo Info => _info;
        

        public void OnSelected()
        {
            MaterialPropertyBlock props = new MaterialPropertyBlock();
            props.SetColor("_Color", Color.red);
            GetComponent<Renderer>().SetPropertyBlock(props);
        }
    }
}

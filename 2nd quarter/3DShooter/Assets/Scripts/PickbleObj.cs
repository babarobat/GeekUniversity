using Game.Interfaces;
using UnityEngine;

namespace Game
{
    class PickbleObj : BaseObjectScene, IPickble
    {
        [SerializeField]
        private  PickbleItemInfo _info;
        public PickbleItemInfo Info => _info;
        
    }
}

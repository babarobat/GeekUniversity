using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class SelectionController : BaseController
    {
        private SelectionModel _selectionModel;
        public SelectionController()
        {
            _selectionModel = MonoBehaviour.FindObjectOfType<SelectionModel>();
        }
        public override void OnUpdate()
        {
            if (!IsActive) return;
            if (_selectionModel.CanSelect)
            {
                
            }
        }
    }
}

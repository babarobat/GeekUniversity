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
        private SelectionView selectionView;
        public SelectionController()
        {
            _selectionModel = MonoBehaviour.FindObjectOfType<SelectionModel>();
            selectionView = MonoBehaviour.FindObjectOfType<SelectionView>();
            Main.Instance.GetInputController.LMousePressed += Select;
        }
        public override void OnUpdate()
        {
            if (!IsActive) return;
            
        }
        void Select()
        {
            if (!IsActive) return;
            var selected = _selectionModel.GetSelectedObj();
            if (selected!=null)
            {
                selectionView.ShowSelectedInfo(selected.Info);
            }
            
        }

    }
}

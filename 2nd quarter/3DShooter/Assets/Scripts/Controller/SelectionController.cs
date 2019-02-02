using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Контроллер для системы выбора обьектов игроком
    /// </summary>
    class SelectionController : BaseController
    {
        /// <summary>
        /// Ссылка на модель системы выбора
        /// </summary>
        private SelectionModel _selectionModel;
        /// <summary>
        /// Ссылка на отображене сисетмы выбора
        /// </summary>
        private SelectionView _selectionView;

        /// <summary>
        /// текущий выбранный предмет
        /// </summary>
        ISelectable _selectedObj;
        /// <summary>
        /// текущий выбранный предмет
        /// </summary>
        ISelectable SelectedObj =>_selectedObj;
        
        public SelectionController()
        {
            _selectionModel = MonoBehaviour.FindObjectOfType<SelectionModel>();
            _selectionView = MonoBehaviour.FindObjectOfType<SelectionView>();
            Main.Instance.GetInputController.LMousePressed += Select;
        }
        public override void OnUpdate()
        {
            if (!IsActive) return;
            
        }
        /// <summary>
        /// Получает выбранный предмет и отдает информацию о нем для отображения в _selectionView
        /// </summary>
        void Select()
        {
            if (!IsActive) return;
            var selected = _selectionModel.GetSelectedObj();
            if (selected != null && selected.Equals(_selectedObj)) return;
            _selectedObj?.OnSelectionChange();
            
            _selectedObj = selected;
            if (selected == null) return;
            _selectedObj?.OnSelected();
            _selectionView.ShowSelectedInfo(selected.Info);


        }

    }
}

using Game.Interfaces;
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
        /// <summary>
        /// Ссылка на камеру
        /// </summary>
        private Camera _cam;
        /// <summary>
        /// Информация об обьекте, в который попал луч
        /// </summary>
        private RaycastHit hit;

        private IInput _input;
        public SelectionController(IInput input)
        {
            _selectionModel = MonoBehaviour.FindObjectOfType<SelectionModel>();
            _selectionView = MonoBehaviour.FindObjectOfType<SelectionView>();
            _cam = MonoBehaviour.FindObjectOfType<Camera>();
            hit = new RaycastHit();
            _input = input;
            _input.OnEnterract += Select;
        }
        /// <summary>
        /// Получает выбранный предмет и отдает информацию о нем для отображения в _selectionView
        /// </summary>
        void Select()
        {
            if (!IsActive) return;
            var selected = GetSelectedObj();
            if (selected != null && selected.Equals(_selectedObj)) return;
            _selectedObj?.OnSelectionChange();
            
            _selectedObj = selected;
            if (selected == null) return;
            _selectedObj?.OnSelected();
            _selectionView.ShowSelectedInfo(selected.Info);
        }
        
        /// <summary>
        /// Выбранный обьект
        /// </summary>
        /// <returns></returns>
        private ISelectable GetSelectedObj()
        {
            if (_selectionModel.CanSelect)
            {
                if (Physics.Raycast(_cam.transform.position,
                                    _cam.transform.TransformDirection(Vector3.forward * _selectionModel.SelectionDistance),
                                    out hit,
                                    _selectionModel.SelectionDistance,
                                    _selectionModel.SelectableLayer))
                {
                    return hit.transform.GetComponent<ISelectable>();
                }
            }
            return null;
        }

    }
}

using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Параметры выбора обьекта
    /// </summary>
    class SelectionModel : BaseObjectScene
    {
        /// <summary>
        /// Слой на котором должен лежать выбранный обьект
        /// </summary>
        [SerializeField]private LayerMask _selectableLayer;
        /// <summary>
        /// Частота, с которой можно перевыбирать обьект
        /// </summary>
        [Range(0, 1)][SerializeField] private float _selectionInterval;
        /// <summary>
        /// Расстояние, на котором можно выбрать обьект
        /// </summary>
        [Range (0,100)][SerializeField] private float _selectionDistance;
        /// <summary>
        /// Ссылка на камеру
        /// </summary>
        private Camera _cam;
        /// <summary>
        /// Информация об обьекте, в который попал луч
        /// </summary>
        private RaycastHit hit;
        /// <summary>
        /// Время, когда первый раз был выбран обьект
        /// </summary>
        private DateTime _lastSelectionTime;

        protected override void Awake()
        {
            base.Awake();

            _lastSelectionTime = DateTime.Now;
            hit = new RaycastHit();
            _cam = FindObjectOfType<Camera>();

        }
        /// <summary>
        /// Можно выбрать обьект?
        /// </summary>
        private bool CanSelect => (DateTime.Now - _lastSelectionTime).Milliseconds > _selectionInterval * 1000;
            
        /// <summary>
        /// Выбранный обьект
        /// </summary>
        /// <returns></returns>
        public ISelectable GetSelectedObj()
        {
            if (CanSelect)
            {
                if (Physics.Raycast(_cam.transform.position, transform.TransformDirection(Vector3.forward * _selectionDistance), out hit, _selectionDistance, _selectableLayer))
                {
                    return hit.transform.GetComponent<ISelectable>();
                }
            }
            return null;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawRay(_cam.transform.position, transform.TransformDirection( Vector3.forward* _selectionDistance));
        }
    }
}

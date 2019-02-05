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
        public LayerMask SelectableLayer => _selectableLayer;
        /// <summary>
        /// Частота, с которой можно перевыбирать обьект
        /// </summary>
        [Range(0, 1)][SerializeField] private float _selectionInterval;
        /// <summary>
        /// Расстояние, на котором можно выбрать обьект
        /// </summary>
        [Range (0,100)][SerializeField] private float _selectionDistance;
        public float SelectionDistance => _selectionDistance;


        /// <summary>
        /// Время, когда первый раз был выбран обьект
        /// </summary>
        private DateTime _lastSelectionTime;

        protected override void Awake()
        {
            base.Awake();

            _lastSelectionTime = DateTime.Now;
            

        }
        /// <summary>
        /// Можно выбрать обьект?
        /// </summary>
        public bool CanSelect => (DateTime.Now - _lastSelectionTime).Milliseconds > _selectionInterval * 1000;
            
        
        
    }
}

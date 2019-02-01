using System;
using UnityEngine;

namespace Game
{
    class SelectionModel : BaseObjectScene
    {
        
        [SerializeField]private LayerMask _selectableLayer;
        [SerializeField] private Transform _rayStartpoint;
        [Range(0, 1)][SerializeField] private float _selectionInterval;
        public float GetSelectionInterval => _selectionInterval;
        [Range (0,100)][SerializeField] private float _selectionDistance;
        private Camera _cam;
        private RaycastHit hit;
        private DateTime _lastSelectionTime;
        ISelectable _selectedObj;
        
        protected override void Awake()
        {
            base.Awake();
            _lastSelectionTime = DateTime.Now;
            hit = new RaycastHit();
            _cam = FindObjectOfType<Camera>();
        }
        private bool CanSelect => (DateTime.Now - _lastSelectionTime).Milliseconds > _selectionInterval * 1000;
            
        
        public ISelectable GetSelectedObj()
        {
            if (CanSelect)
            {
                if (Physics.Raycast(_rayStartpoint.position, transform.TransformDirection(Vector3.forward * _selectionDistance), out hit, _selectionDistance, _selectableLayer))
                {

                    _selectedObj?.OnSelectionChange();
                    _selectedObj = hit.transform.GetComponent<ISelectable>();
                    _selectedObj?.OnSelected();
                    return _selectedObj;
                }
                else
                {
                    _selectedObj?.OnSelectionChange();
                }              
            }
            return null;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawRay(_rayStartpoint.position, transform.TransformDirection( Vector3.forward* _selectionDistance));
        }
    }
}

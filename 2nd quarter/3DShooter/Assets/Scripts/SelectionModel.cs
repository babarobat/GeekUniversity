using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private ISelectable _selectedObj;
        private DateTime _lastSelectionTime;
        

        protected override void Awake()
        {
            base.Awake();
            _lastSelectionTime = DateTime.Now;
            hit = new RaycastHit();
            _cam = FindObjectOfType<Camera>();
        }
        public bool CanSelect => (DateTime.Now - _lastSelectionTime).Milliseconds > _selectionInterval * 1000;
            
        
        public ISelectable GetSelectedObj()
        {
            if (Physics.Raycast(_rayStartpoint.position, Vector3.forward,out hit, _selectionDistance, _selectableLayer))
            {
                return hit.transform.GetComponent<ISelectable>();
            }
            return null;
        }
        private void OnDrawGizmosSelected()
        {
            
        }
    }
}

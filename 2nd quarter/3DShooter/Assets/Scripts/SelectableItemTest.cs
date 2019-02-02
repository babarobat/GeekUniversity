using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ПРИМЕР. Не является частью программы. Реализует интерфейс Iselectable.
    /// Для того что бы обьект мог быть выбран, на нем должен стоять соответсвующий слой.
    /// </summary>
    class SelectableItemTest : BaseObjectScene, ISelectable
    {
        [SerializeField]
        private SelectableItemInfo _info;
        public SelectableItemInfo Info => _info;
        private Color _normalColor;
        public Renderer Renderer { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Layer = 11;
            Renderer = GetComponent<Renderer>();
            _normalColor = Renderer.material.color;
        }

        public void OnSelected()
        {
            Renderer.material.color = Color.red;
            
        }

        public void OnSelectionChange()
        {
            Renderer.material.color = _normalColor;
            
        }
    }
}

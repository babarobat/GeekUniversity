using UnityEngine;

namespace Game
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        private int _layer;
        public Transform Transform { get; private set; }
        public Rigidbody Rigidbody { get; private set; }

        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                ChangeLayerForAllChildren(transform,_layer);
            }
        }
        void ChangeLayerForAllChildren(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;
            if (obj.childCount <= 0) return;
            foreach (Transform item in obj)
            {
                ChangeLayerForAllChildren(item, layer);
            }
            
        }
        protected virtual void Awake()
        {
            
            Transform = transform;
            Rigidbody = GetComponent<Rigidbody>();
        }

    }
}


using UnityEngine;

namespace Game
{
    /// <summary>
    /// Базовый обьект для моделей данных.
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        /// <summary>
        /// Слой обьекта
        /// </summary>
        private int _layer;
        /// <summary>
        /// Позиция, поворот и размер обьекта
        /// </summary>
        public Transform Transform { get; private set; }
        /// <summary>
        /// Физика твердого тела обьекта
        /// </summary>
        public Rigidbody Rigidbody { get; private set; }
        /// <summary>
        /// Слой обьекта. От 0 до 31
        /// </summary>
        public int Layer
        {
            get => _layer;
            set
            {
                if (value < 0||value>31)
                {
                    throw new System.Exception($"Попытка присвоить объекту {name} недопустимое значение слоя");
                }
                else
                {
                    _layer = value;
                    ChangeLayerForAllChildren(transform, _layer);
                }
            }
        }
        /// <summary>
        /// Изменяет слой для обьекта на сцене и всех его потомков
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="layer">Слой</param>
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


using UnityEngine;

namespace Game
{
    /// <summary>
    /// Базовый обьект для моделей данных.
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        
        /// <summary>
        /// Позиция, поворот и размер обьекта
        /// </summary>
        public Transform Transform { get; private set; }
        /// <summary>
        /// Слой обьекта. От 0 до 31
        /// </summary>
        public int Layer
        {
            get => gameObject.layer;
            set
            {
                if (value < 0||value>31)
                {
                    throw new System.Exception($"Попытка присвоить объекту {name} недопустимое значение слоя");
                }
                else
                {
                    
                    ChangeLayerForAllChildren(transform, value);
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
            
        }
        /// <summary>
        /// Изменить видимость для всех пацанят
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        void ChangeVisibilityForAllChildren(Transform obj, bool value)
        {
            var r =  obj.gameObject.GetComponent<Renderer>();
            if (r != null)
            {
                r.enabled = value;
            }
            if (obj.childCount <= 0) return;
            foreach (Transform item in obj)
            {
                ChangeVisibilityForAllChildren(item, value);
            }
        }
        /// <summary>
        /// Обьект видим? Вкл/выкл Renderer
        /// </summary>
        public bool IsVisible
        {
            get => gameObject.GetComponent<Renderer>().enabled;
            set
            {
                ChangeVisibilityForAllChildren(transform, value);
            }
        }
        

    }
}


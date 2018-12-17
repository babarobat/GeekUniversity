using System.Collections;
using UnityEngine;
namespace Game.Controllers
{
    /// <summary>
    /// логика и параметры взрыва обьекта
    /// </summary>
    class ExplosionController:BaseComponentController
    {
        /// <summary>
        /// Префаб модели персонажа, поделенной на куски для взрыва
        /// </summary>
        [Tooltip("Модель персонажа, разделенная на части")]
        [SerializeField]
        private GameObject _explodedModel;

        /// <summary>
        /// Ссылка на компонент Effector2D
        /// </summary>\
        [Tooltip("Ссылка на компонент Effector2D")]
        [SerializeField]
        private Effector2D _effector;
        /// <summary>
        /// Префаб эффекта взрыва
        /// </summary>
        [Tooltip("Префаб эффекта взрыва")]
        [SerializeField]
        private GameObject _explosionPrefab;
        
       
        protected override void Start()
        {
            base.Start();
            transform.parent.GetComponentInChildren<HealthController>().HpIsZero+= Explode;
            _explodedModel.SetActive(false);
            
        }
        /// <summary>
        /// Взрывает и уничтожает обьект
        /// </summary>
        /// <returns></returns>
        private IEnumerator Explosion()
        {
            Vector3 pos = transform.position;
            GameObject parent = transform.parent.gameObject;
            transform.SetParent(null);
            Destroy(parent);
            transform.position = pos;
            _explodedModel.SetActive(true);
            FindObjectOfType<CameraController>().ShakeCam();
            Instantiate(_explosionPrefab, transform);
            yield return new WaitForSeconds(0.5f);
            _effector.enabled = false;
            var colliders = _explodedModel.GetComponentsInChildren<Collider2D>();
            foreach (var item in colliders)
            {
                item.enabled = false;
            }
            Destroy(gameObject,2);
        }
        /// <summary>
        /// Запускает алгоритм взрыва обьекта
        /// </summary>
        public void Explode()
        {
            StartCoroutine(Explosion());
        }
    }
}

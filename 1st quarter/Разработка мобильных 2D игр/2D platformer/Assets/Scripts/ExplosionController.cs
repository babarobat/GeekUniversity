using System.Collections;
using UnityEngine;
namespace Game.Controllers
{
    class ExplosionController:BaseComponentController
    {
        [SerializeField]
        private GameObject _explodedModel;
        [SerializeField]
        private Effector2D _effector;
        [SerializeField]
        private float _destoryTime;
        [SerializeField]
        private GameObject _explosionPrefab;
        
       
        private void Start()
        {
            _explodedModel.SetActive(false);
        }
        private IEnumerator Explosion()
        {
            Vector3 pos = transform.position;
            transform.SetParent(null);
            transform.position = pos;
            _explodedModel.SetActive(true);
            Instantiate(_explosionPrefab, transform);
            yield return new WaitForSeconds(0.5f);
            _effector.enabled = false;
            var colliders = _explodedModel.GetComponentsInChildren<Collider2D>();
            foreach (var item in colliders)
            {
                item.enabled = false;
            }
            Destroy(gameObject);
        }
        public void Explode()
        {
            StartCoroutine(Explosion());
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
       
        private void Start()
        {
            _explodedModel.SetActive(false);
        }
        private IEnumerator Explosion()
        {
            _explodedModel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _effector.enabled = false;
        }
        public void Explode()
        {
            StartCoroutine(Explosion());
        }
    }
}

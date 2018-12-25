using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;


namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    class SpriteTrap:MonoBehaviour
    {
        [SerializeField]
        string[] _canInteract;
        [SerializeField]
        GameObject _destroyPrefab;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_canInteract.Contains(collision.gameObject.tag))
            {
                var pos = transform.position;
                var effect = Instantiate(_destroyPrefab);
                effect.transform.SetParent(null);
                effect.transform.position = pos;
                Destroy(effect, 1);
                Destroy(gameObject);
            }
        }
    }
}

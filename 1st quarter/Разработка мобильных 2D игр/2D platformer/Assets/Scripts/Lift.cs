using System;
using System.Collections;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    class Lift:MonoBehaviour
    {
       
        [SerializeField]
        Vector2[] _stopPositions;
        int posIndex = 0;
        [SerializeField]
        float _speed;
        [SerializeField]
        Trigger[] _switches;
        bool isWorking = false;
        private void Start()
        {
            transform.position = _stopPositions[0];
            foreach (var _switch in _switches)
            {
                _switch.OnInteract += MoveLift;
            } 
        }
        void MoveLift(TriggerEventArgs args)
        {

            if (!isWorking)
            {
                StartCoroutine(MoveNext());
            }
            
        }
        IEnumerator MoveNext()
        {
            float dist = 1;
            posIndex = posIndex < _stopPositions.Length - 1 ? posIndex + 1 : 0;
            isWorking = true;
            while (dist > 0.1)
            {
                var dir = _stopPositions[posIndex] -(Vector2)transform.position;
                dist = Vector2.Distance(transform.position, _stopPositions[posIndex]);
                transform.position += (Vector3)dir.normalized * _speed * Time.deltaTime;
                yield return null;
            }
            isWorking = false;
            transform.position =_stopPositions[posIndex];
            

        }


    }
}

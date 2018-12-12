
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class Platform:MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        Transform[] _movingPoints;
        int _pointIndex = 0;
        [SerializeField]
        bool _patroling;

        private void Update()
        {
            if (_movingPoints.Length>1&& _patroling)
            {

                var dir = transform.position - _movingPoints[_pointIndex].position;
                var dist = Vector2.Distance(transform.position, _movingPoints[_pointIndex].position);
                transform.Translate(dir * _speed * Time.deltaTime);
                if (dist < 0.1)
                {
                    if (_pointIndex < _movingPoints.Length - 1) 
                    {
                        _pointIndex++;
                    }
                    else
                    {
                        _pointIndex = 0;
                    }
                } 
            }
        }
        IEnumerator MoveTo(Vector3 pos)
        {
            var dist = Vector2.Distance( transform.position, pos);
            while (dist>0.1)
            {
                transform.Translate(pos*_speed*Time.deltaTime);
                yield return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    class MapScroller:MonoBehaviour
    {
        private CameraController _cam;
        [SerializeField]
        private Transform _bg;
        [Range(0,10)]
        [SerializeField]
        private float _scrollSpeed;
        Vector3 _startCamPos;
        Vector3 _startBGPos;
        Vector2 desPos;
        float _dist;
        private void Start()
        {

            _cam = FindObjectOfType<CameraController>();

            _startCamPos = FindObjectOfType<PlayerController>().transform.position;
            _startBGPos = _bg.transform.position;
            desPos.y = _bg.position.y;
        }
        
        private void Update()
        {
            

            _dist = Mathf.Abs(_startCamPos.x - _cam.transform.position.x);
            
            desPos.x = _startCamPos.x < _cam.transform.position.x ? _startBGPos.x - _dist*_scrollSpeed/10 : _startBGPos.x + _dist * _scrollSpeed/10;
            
            
            _bg.transform.position = (Vector3)desPos;


        }
        void SetCam()
        {
           
        }
    }
}

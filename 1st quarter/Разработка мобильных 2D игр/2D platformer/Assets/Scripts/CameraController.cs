using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {

        private Transform target;
        private Vector3 pos;
        // Use this for initialization
        void Start()
        {
            target = FindObjectOfType<PlayerController>().transform;
            pos = new Vector3();
            pos.z = transform.position.z;


        }

        // Update is called once per frame
        void Update()
        {
            pos.x = target.position.x;
            pos.y = target.position.y;
            
            transform.position = pos;
        }
    }
}


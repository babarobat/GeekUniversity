using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererController : MonoBehaviour {
    TrailRenderer tr;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        tr = GetComponent<TrailRenderer>();
        pos = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            pos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            
        }
#endif

#if UNITY_ANDROID
        pos.x = Camera.main.ScreenToWorldPoint(Input.touches[0].position).x;
        pos.y = Camera.main.ScreenToWorldPoint(Input.touches[0].position).y;
        
#endif
        tr.transform.position = pos;
    }
}

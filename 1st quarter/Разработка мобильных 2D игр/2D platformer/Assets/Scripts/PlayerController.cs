using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;
public class PlayerController : MonoBehaviour {
    
    private BaseComponentController [] _controllers;    
    private ControlParams e;    
    private Animator _animator;
	
	void Start () {

        e = new ControlParams();
        _animator = GetComponentInChildren<Animator>();
        _controllers = GetComponentsInChildren<BaseComponentController>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        e.Horizontal = InputController.Instance.ControlParams.Horizontal;
        e.Jump = InputController.Instance.ControlParams.Jump;
        foreach (var controller in _controllers)
        {
            controller.Action(e);
        }

        //_map.Translate(Vector2.right*-hor*.3f*Time.deltaTime);
        
        //_animator.SetFloat("VelocityX",Mathf.Abs(e.Horizontal));
        
        

    }
    
}

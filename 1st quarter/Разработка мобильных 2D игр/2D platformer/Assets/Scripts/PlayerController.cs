using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;
/// <summary>
/// Содержит логику и параметры управления персонажем
/// </summary>
public class PlayerController : BaseCharacterController
{

    /// <summary>
    /// Сила прыжка
    /// </summary>
    [Tooltip("Сила прыжка")][SerializeField] private float _jumpForce = 600;
    /// <summary>
    /// Слой, с которого можно прыгать
    /// </summary>
    [Tooltip("название слоя, с которого можно прыгать")] [SerializeField] private LayerMask _whatIsGround;
    /// <summary>
    /// Трансформ для определения нахождения на земле
    /// </summary>
    [Tooltip("Трансформ для определения нахождения на земле")] [SerializeField] private Transform _groundCheck;

    
    /// <summary>
    /// Персонаж находится на земле?
    /// </summary>
    private bool isGrounded;
    /// <summary>
    /// Радиус проверки на нахождение на земле
    /// </summary>
    private const float groundedRadius = .2f;
   

    [SerializeField] private Transform _map;
    void Update()
    {
        var horizontal = InputController.Instance.ControlParams.Horizontal;
        var jump = InputController.Instance.ControlParams.Jump;
        
        _map.Translate(Vector2.right * -horizontal * .3f * Time.deltaTime);
        

        _animationController.Move(horizontal);
        _moveMentController.Move(_speed, horizontal);

        if (jump&&isGrounded)
        {
            isGrounded = false;
            _animationController.Jump();
            _moveMentController.Jump(_jumpForce);
        }
    }
    private void FixedUpdate()
    {

        Collider2D[] collidrs = Physics2D.OverlapCircleAll(_groundCheck.position, groundedRadius, _whatIsGround);
        foreach (var col in collidrs)
        {
            if (col.gameObject != gameObject)
            {
                isGrounded = true;
                _animationController.Grounded();
            }
        }
    }

}

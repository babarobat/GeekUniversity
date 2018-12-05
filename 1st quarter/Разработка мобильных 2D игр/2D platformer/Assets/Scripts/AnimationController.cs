using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Определяет логику и параметры анимации
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimationController : BaseComponentController
    {
        /// <summary>
        /// ссылка на компонет Аниматор
        /// </summary>
        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            //GetComponentInParent<BaseCharacterController>().Move += Move;
        }
        /// <summary>
        /// Запускает анимацию движения
        /// </summary>
        /// <param name="hor">скорость движения по горизонтали</param>
        public void Move(float value)
        {
            _animator.SetFloat("VelocityX", Mathf.Abs(value));
        }
        /// <summary>
        /// Запускает анимацию движения
        /// </summary>
        public void Jump()
        {
            _animator.SetBool("IsJumping",true);
        }
        /// <summary>
        /// Анимация приземления
        /// </summary>
        public void Grounded()
        {
            _animator.SetBool("IsJumping", false);
        }
        
    }
}

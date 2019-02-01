using UnityEngine;
namespace Game
{
    class PlayerModel : BaseObjectScene
    {
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private float _rotateSpeed;


        private Camera _head;

        protected override void Awake()
        {
            base.Awake();
            _head = FindObjectOfType<Camera>();
        }
        
        public void Rotate(Vector3 rotation)
        {
            _head. transform.Rotate(0f, rotation.y*_rotateSpeed , 0f, Space.World);
            _head.transform.Rotate(rotation.x* _rotateSpeed, 0f, 0f, Space.Self);  
        }
    }
}


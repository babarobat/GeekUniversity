using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    /// <summary>
    /// Параметры управления игроком
    /// </summary>
    class PlayerModel : BaseObjectScene
    {
        
        /// <summary>
        /// Скорость поворота камеры
        /// </summary>
        [SerializeField][Range(0,300)]
        private float _mouseSensivity;
        
        /// <summary>
        /// Камера
        /// </summary>
        private Camera _head;

        #region БезДокументации




        
         
        float _xAxisClamp;
        float _yAxisClamp;

        Vector3 _forwardMovement;
        Vector3 _strafeMovement;

        [SerializeField]
        float _movementSpeed;
        [SerializeField]
        float _strafeSpeed;
        [SerializeField]
        float _maxMovementSpeed;
        [SerializeField]
        float _maxStrafeSpeed;

        
       
        #endregion



        protected override void Awake()
        {
            base.Awake();

            FindCamera();


            


            _forwardMovement = new Vector3();
            _strafeMovement = new Vector3();
        }
        /// <summary>
        /// Поворачивает камеру на заданные углы по оси X и Y в градусах
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(Vector2 rotation)
        {
            
            _xAxisClamp += rotation.y *_mouseSensivity*Time.deltaTime;
            
            if (_xAxisClamp>90.0f)
            {
                
                _xAxisClamp = 90.0f;
                rotation.y = 0.0f;
                ClampAxisRotationToValue(270.0f);
            }
            else if (_xAxisClamp<-90.0f)
            {
               
                _xAxisClamp = -90.0f;
                rotation.y = 0.0f;
                ClampAxisRotationToValue(90f);
            }

            _head.transform.Rotate(- rotation.y * _mouseSensivity * Time.deltaTime, 0,0,Space.Self);
            transform.Rotate(0, rotation.x * _mouseSensivity * Time.deltaTime, 0, Space.World);


        }
        private void ClampAxisRotationToValue(float value)
        {
            Vector3 eulerRot = _head.transform.eulerAngles;
            eulerRot.x = value;
            _head.transform.eulerAngles = eulerRot;
        }
        
        void FindCamera()
        {
            _head = FindObjectOfType<Camera>();
        }

       
        public void Move(float hor, float vert, float speedmultyplyer)
        {

            //
            _forwardMovement = _head.transform.forward * vert * speedmultyplyer * _movementSpeed* Time.deltaTime;
            _strafeMovement = transform.right * hor * speedmultyplyer * _strafeSpeed* Time.deltaTime;
           

            Rigidbody.AddForce(_forwardMovement);
            Rigidbody.AddForce(_strafeMovement);


            Vector3 movementClamp = new Vector3();
            movementClamp.z = Mathf.Clamp(Rigidbody.velocity.z, -_maxMovementSpeed, _maxMovementSpeed);
            movementClamp.x = Mathf.Clamp(Rigidbody.velocity.x, -_maxStrafeSpeed, _maxStrafeSpeed);
            movementClamp.y = Rigidbody.velocity.y;
            Rigidbody.velocity = movementClamp;
        }
        public void Move(float hor, float vert)
        {
            Move(hor, vert,1);
        }
    }
}


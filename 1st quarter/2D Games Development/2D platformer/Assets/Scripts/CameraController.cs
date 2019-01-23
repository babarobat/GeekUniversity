using System.Collections;
using UnityEngine;
using Game.Controllers;

namespace Game
{
    /// <summary>
    /// Содержит логиу и параметры управления камерой
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Цель, за которой движется камера
        /// </summary>
        private PlayerController target;
        /// <summary>
        /// Ссылка на контроллер здоровья игрока
        /// </summary>
        HealthController _playerHp;
        /// <summary>
        /// Ссылка на компонент типа Аниматор
        /// </summary>
        Animator _anim;
        /// <summary>
        /// Следовать за игроком?
        /// </summary>
        bool folowPlayer = true;
        
        /// <summary>
        /// Список тригеров, содержащих параметры камеры
        /// </summary>
        [SerializeField]
        private Trigger[] camOffsetTriggers;
        /// <summary>
        /// Желаемая позиция камеры
        /// </summary>
        Vector2 DesPos;
        /// <summary>
        /// Отступ по Х
        /// </summary>
        [SerializeField]
        float _offsetX;
        /// <summary>
        /// Отступ по У
        /// </summary>
        [SerializeField]
        float _offsetY;
        /// <summary>
        /// Отступ по Z
        /// </summary>
        [SerializeField]
        float _offsetZ;
        /// <summary>
        /// Расстояние, после которого камера начинает следовть за игроком
        /// </summary>
        public float startFollowDist;
        /// <summary>
        /// Скорость следовния
        /// </summary>
        public float smoothSpeed;
        /// <summary>
        /// Играет анимация?
        /// </summary>
        bool animIsPlaying = false;
        /// <summary>
        /// Ссылка на компонент Камера
        /// </summary>
        Camera _cam;
        /// <summary>
        /// Расстояние, на котором будет проигрываться анимация шейккам
        /// </summary>
        private const float maxDistanceToShakeCam = 10;
        /// <summary>
        /// Время, которое камера показывает обьект
        /// </summary>
        private const float SHowTime = 3;
        // Use this for initialization
        void Start()
        {
            DesPos = new Vector2();
            _cam = GetComponentInChildren<Camera>();
            target = FindObjectOfType<PlayerController>();
            _anim = GetComponent<Animator>();
            _playerHp = target.GetComponentInChildren<HealthController>();
            transform.position = target.transform.position;
            _playerHp.OnHpChange += HitPlayerEffect;
            _playerHp.HpIsZero += ShowPlayer;
            foreach (var item in camOffsetTriggers)
            {
                 item.OnEnter += ChangeOfffset;
            }
        }
        /// <summary>
        /// Изменяет параметры камеры
        /// </summary>
        /// <param name="e">список параметров</param>
        void ChangeOfffset(TriggerEventArgs e)
        {
            _offsetX = e.VectorMeta.x;
            _offsetY = e.VectorMeta.y;
            _offsetZ = e.VectorMeta.z;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3((startFollowDist+_offsetX)*2, (startFollowDist+_offsetY)*2, startFollowDist));
        }
        
        void Update()
        {
            if (folowPlayer)
            {
                DesPos = target.transform.position;
                var xMod = target.transform.eulerAngles.y == 180 ? -1:1;
                DesPos.x += _offsetX* xMod;
                DesPos.y += _offsetY;
                
                if (Vector2.Distance(DesPos, transform.position)>startFollowDist)
                {
                    transform.position = Vector2.Lerp(transform.position, DesPos, smoothSpeed);
                    _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _offsetZ, smoothSpeed);

                }
                
            } 
        }

        public void EndAnim()
        {
            animIsPlaying = false;
        }
       /// <summary>
       /// Трясет камеру, если обьект, вызывающий тряску камеры находится на нужном расстоянии
       /// </summary>
       /// <param name="sender">Обьект, вызывающий тряску камеры</param>
        public void ShakeCam(GameObject sender)
        {
            if (Vector2.Distance(sender.transform.position, transform.position)< maxDistanceToShakeCam && animIsPlaying == false)
            {
                animIsPlaying = true;
                _anim.SetTrigger("Shake");
            }            
        }
        /// <summary>
        /// Вызывает анимацию при нанесении урона игроку
        /// </summary>
        /// <param name="x"></param>
        public void HitPlayerEffect(int x)
        {
            _anim.SetTrigger("Damaged");
        }
        /// <summary>
        /// Передвигает камеру в заданную позицию
        /// </summary>
        /// <param name="pos">Позиция, которую нужно показать</param>
        public void ShowPos(Vector2 pos)
        {
            StartCoroutine(ShowPosCor(pos, SHowTime));  
        }
        
        public void SwitchFollowing(bool value)
        {
            folowPlayer = value;
        }
        /// <summary>
        /// Показхывает игрока
        /// </summary>
        public void ShowPlayer()
        {
            DesPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = DesPos;

        }
        /// <summary>
        /// Корутин для передвижения к позиции
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        IEnumerator ShowPosCor(Vector2 pos, float holdTime)
        {
            folowPlayer = false;
            target.IsControllable(false);
            float t = 0f;
            while (t <= holdTime)
            {

                transform.position = Vector2.Lerp(transform.position, pos, t / holdTime);
                
                t += Time.deltaTime;
                yield return null;

            }
            
            transform.position = pos;
            yield return new WaitForSeconds(1);
            t = 0f;
            target.IsControllable(true);
            while (t <= holdTime)
            {                
                transform.position = Vector2.Lerp(transform.position, target.transform.position, t / holdTime);
                t += Time.deltaTime;
                yield return null;
            }
            
            transform.position = target.transform.position;
            folowPlayer = true;
        }
       
        
    }
    
}


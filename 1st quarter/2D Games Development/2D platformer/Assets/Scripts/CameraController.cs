using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;

namespace Game
{
    public class CameraController : MonoBehaviour
    {

        private PlayerController target;
        private Vector3 pos;
        HealthController _playerHp;
        Animator _anim;
        bool folowPlayer = true;
        

        [SerializeField]
        private Trigger[] camOffsetTriggers;

        Vector2 DesPos;
        [SerializeField]
        float _offsetX;
        [SerializeField]
        float _offsetY;
        public float startFollowDist;
        public float smoothSpeed;


        private const float maxDistanceToShakeCam = 10;
        // Use this for initialization
        void Start()
        {
            DesPos = new Vector2();
            target = FindObjectOfType<PlayerController>();
            _anim = GetComponent<Animator>();
            _playerHp = FindObjectOfType<PlayerController>().GetComponentInChildren<HealthController>();
            transform.position = target.transform.position;
            _playerHp.OnHpChange += HitPlayerEffect;
            _playerHp.HpIsZero += ShowPlayer;
            foreach (var item in camOffsetTriggers)
            {
                 item.OnEnter += ChangeOfffset;
            }
        }
        void ChangeOfffset(TriggerEventArgs e)
        {
            _offsetX = e.VectorMeta.x;
            _offsetY = e.VectorMeta.y;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3((startFollowDist+_offsetX)*2, (startFollowDist+_offsetY)*2, startFollowDist));
        }
        // Update is called once per frame
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
                }
                
            }
            
            
            
        }
        public void ShakeCam(GameObject sender)
        {
            if (Vector2.Distance(sender.transform.position, transform.position)< maxDistanceToShakeCam)
            {
                _anim.SetTrigger("Shake");
            }
            
        }
        public void HitPlayerEffect(int x)
        {
            _anim.SetTrigger("Damaged");
        }
        public void ShowPos(Vector2 pos)
        {
            StartCoroutine(ShowPosCor(pos));
            
        }
        public void SwitchFollowing(bool value)
        {
            folowPlayer = value;
        }
        public void ShowPlayer()
        {
            DesPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = DesPos;

        }
        IEnumerator ShowPosCor(Vector2 pos)
        {
            folowPlayer = false;
            target.IsControllable(false);
            float t = 0f;
            while (t <= 3)
            {

                transform.position = Vector2.Lerp(transform.position, pos, t / 3);
                
                t += Time.deltaTime;
                yield return null;

            }
            
            transform.position = pos;
            yield return new WaitForSeconds(1);
            t = 0f;
            target.IsControllable(true);
            while (t <= 3)
            {
                
                transform.position = Vector2.Lerp(transform.position, target.transform.position, t / 3);

                t += Time.deltaTime;
                yield return null;

            }
            
            transform.position = target.transform.position;
            folowPlayer = true;
        }
        
        
    }
    
}


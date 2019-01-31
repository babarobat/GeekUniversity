using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    class LoadManager:MonoBehaviour
    {
        [SerializeField]
        Trigger[] _checkPoints;
        [SerializeField]
        Vector2 _loadPos;
        [SerializeField]
        Transform BossPoint;
        
        PlayerController _player;


        private void Start()
        {
            foreach (var item in _checkPoints)
            {
                item.OnEnter += SetLoadPos;
            }
            _player = FindObjectOfType<PlayerController>();
            if (_player!=null)
            {
                _player.OnPlayerDead += LoadFromChekPoint;
            }
            
        }
        void SetLoadPos(TriggerEventArgs e)
        {
            
            _loadPos = e.Sender.transform.position;
            e.Sender.GetComponent<SpriteRenderer>().enabled = true;

            foreach (var item in _checkPoints)
            {
                if (item!= e.Sender)
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;

                }
            }


        }
        public void LoadNearBoss()
        {
            
            _loadPos = BossPoint.position;
            LoadFromChekPoint();

        }
        public void LoadFromChekPoint()
        {

            _player.transform.position = _loadPos;
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        public void LoadScene(int sceneIndex)
        {
            GlobalGameManager.Instance.ChangeState(GameStates.GameNormal);
            SceneManager.LoadScene(sceneIndex);
        }
        IEnumerator EndGameCor()
        {
            yield return new WaitForSeconds(6);
            LoadScene(0);
        }
        public GameObject FadePannel;
        public void EndGame()
        {
            FadePannel.SetActive(true);
            StartCoroutine(EndGameCor());
        }
        
    }
}

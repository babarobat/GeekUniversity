using System;
using System.Collections.Generic;
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
        
        PlayerController _player;


        private void Start()
        {
            foreach (var item in _checkPoints)
            {
                item.OnEnter += SetLoadPos;
            }
            _player = FindObjectOfType<PlayerController>();
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
            SceneManager.LoadScene(sceneIndex);
        }
        
    }
}

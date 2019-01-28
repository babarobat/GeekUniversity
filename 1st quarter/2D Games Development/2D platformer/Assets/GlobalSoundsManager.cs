using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Game.Controllers;
using UnityEngine.UI;
using Game.Audio;
namespace Game
{
    public class GlobalSoundsManager : Singleton<GlobalSoundsManager>
    {
        [SerializeField]
        private SoundComponent _music;
        [SerializeField]
        private SoundComponent _ambience;

        
        


        private GlobalGameManager gl;
        

        void Start()
        {
            
            gl = GlobalGameManager.Instance;
            gl.OnStateChange += PlayStageMusic;  
            StartCoroutine(PlayStageMusCor());
        }
        IEnumerator PlayStageMusCor()
        {
            
           yield return new WaitForFixedUpdate();
            PlayStageMusic(gl.CurrentState);

        }
        
        void PlayTheme(string themeName)
        {
            if (!_music.SoundIsPlaying(themeName))
            {
                _music.Play(themeName);
            }
        }
        void PlayStageMusic(GameStates state)
        {
            switch (state)
            {
                case GameStates.MainMenu:
                    break;
                case GameStates.Pause:
                    break;
                case GameStates.GameNormal:
                    PlayTheme("GameTheme");
                    break;
                    
                case GameStates.GameFight:
                    break;
                case GameStates.GameBoss:
                    break;
                case GameStates.Death:
                    break;
                default:
                    break;
            }
            
        }
        
    }
}


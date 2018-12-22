using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Game.Controllers;
using UnityEngine.UI;
namespace Game
{
    public class GlobalSoundsManager : Singleton<GlobalSoundsManager>
    {
        [SerializeField]
        private SoundController _music;
        [SerializeField]
        private SoundController _ambience;

        int i = 0;
        


        private GlobalGameManager gl;
        

        void Start()
        {
            print (i);
            gl = GlobalGameManager.Instance;
            gl.OnStateChange += PlayStageMusic;  
            StartCoroutine(Xer());
        }
        IEnumerator Xer()
        {
            i++;
           yield return new WaitForFixedUpdate();
            PlayStageMusic(gl.CurrentState);

        }
        
        void PlayTheme(string themeName)
        {
            if (!_music.SoundIsPlaying(themeName))
            {
                _music.PlaySound(themeName, true);
            }
        }
        void PlayStageMusic(GameStates state)
        {
            PlayTheme(state.ToString());
        }
        
    }
}


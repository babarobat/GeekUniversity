using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;

namespace Game
{
    public class GlobalSoundsManager : MonoBehaviour
    {
        [SerializeField]
        private SoundController _music;
        [SerializeField]
        private SoundController _ambience;

        GlobalGameManager gl;

        void Start()
        {
            gl = GlobalGameManager.Instance;
            gl.OnStateChange += PlayStageMusic;
            //PlayStageMusic(gl.CurrentState);
            _music.Clips[0].Source.Play();
            PlayTheme("1");
           
        }
        private void Update()
        {
            //print(_music.Clips);


        }
        void PlayTheme(string themeName)
        {
            //if (!_music.SoundIsPlaying(themeName))
            //{
                _music.PlaySound(themeName, true);
            //}
        }
        void PlayStageMusic(GameStates state)
        {
            
            PlayTheme(state.ToString());
        }
    }
}


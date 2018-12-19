using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using Game.Audio;

namespace Game.Controllers
{
   
    public class SoundController:BaseComponentController
    {
        static System.Random rnd = new System.Random();
        [SerializeField]
        private Sound[] _clips;
        private bool _makeIndependentAfterStart;
        private bool _autoDestroy;

        protected override void Start()
        {
            foreach (var item in _clips)
            {
                var source = item.Source = gameObject.AddComponent<AudioSource>();
                source.outputAudioMixerGroup = item.Out;
                source.playOnAwake = item.PlayOnAwake;
                source.loop = item.Loop;
                source.clip = item.Clip;
                source.spatialBlend = item.SpetialBlend;
                source.volume = item.Volume;
                if (item.PlayOnAwake)
                {
                    source.Play();
                }
                
            }
            
            //PlaySound("GamePlay",true);
        }
        public void PlaySound(string name, bool loop)
        {
            
            Sound sound = Array.Find(_clips, s => s.Name == name);
            sound.Source.loop = loop;
            sound.Play();
            
        }
        public void StopSound()
        {
            Sound sound = Array.Find(_clips, s => s.Name == name);
            sound.Stop();
        }
        //IEnumerator FadeOut(float fadeTime)
        //{
        //    float t = 0f;
        //    while (t <= fadeTime)
        //    {

        //        _healthBar.color = Color.Lerp(_healthBar.color, hideColor, t / fadeTime);
        //        _healthBarBG.color = Color.Lerp(_healthBarBG.color, hideColor, t / fadeTime);
        //        t += Time.deltaTime;
        //        yield return null;

        //    }

        //    _healthBar.color = hideColor;
        //    _healthBarBG.color = hideColor;
        //}

    }
}

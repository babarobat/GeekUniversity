using System;
using System.Collections;
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
        
        [SerializeField]
        private Sound[] _clips;
        public Sound[] Clips
        { get=> _clips; private set => _clips=value; }
        protected override void Start()
        {
            foreach (var item in _clips)
            {
                item.Source = gameObject.AddComponent<AudioSource>();
                item.Source.outputAudioMixerGroup = item.Out;
                item.Source.playOnAwake = item.PlayOnAwake;
                item.Source.loop = item.Loop;
                item.Source.clip = item.Clip;
                item.Source.spatialBlend = item.SpetialBlend;
                item.Source.volume = item.Volume;
                item.Source.maxDistance = item.MaxDistance;
                item.Source.rolloffMode = AudioRolloffMode.Custom;
                if (item.PlayOnAwake)
                {
                    item.Source.Play();
                } 
            }
        }
        
        public void PlaySound(string name, bool loop)
        {
            Sound sound = GetSound(name);
            sound.Source.loop = loop;
            sound.Source.Play();
        }
        public void StopSound(string name)
        {
            GetSound(name).Stop();
        }
        public bool SoundIsPlaying(string name)
        {
            return GetSound(name).Source.isPlaying;
        }
        private Sound GetSound(string name) => Array.Find(_clips, s => s.Name == name);
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

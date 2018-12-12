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
    [RequireComponent(typeof(AudioSource))]
    class SoundController:BaseComponentController
    {
        System.Random rnd = new System.Random();
        private Sound[] _clips;
        private AudioSource _source;
        protected override void Start()
        {
            _source = GetComponent<AudioSource>();
        }
        public void PlaySound(string name)
        {
            Sound sound = Array.Find(_clips, s => s.Name == name);
            _source.clip = sound.Clip;
            _source.Play();
        }
        public void PlaySound(int index)
        {
            Sound sound = _clips[index];
            _source.clip = sound.Clip;
            _source.Play();
        }

        public void PlaySound(int index, bool overPlay)
        {
            if (overPlay|| !_source.isPlaying)
            {
                PlaySound(index);
            }
        }
        public void PlaySound(string name, bool overPlay)
        {
            if (overPlay || !_source.isPlaying)
            {
                PlaySound(name);
            }
        }
        public void PlayRandomSound(bool overPlay)
        {
           var r = rnd.Next(0, _clips.Length);
            if (overPlay || !_source.isPlaying)
            {
                PlaySound(r);
            }
        }
        public void Stop()
        {
            _source.Stop();
        }


    }
}

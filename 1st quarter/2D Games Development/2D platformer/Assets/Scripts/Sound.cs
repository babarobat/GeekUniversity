using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Audio;
using UnityEngine;

namespace Game.Audio
{
    [Serializable]
    public class Sound
    {
        public AudioClip Clip;
        public string Name;
        [HideInInspector]
        public AudioSource Source;
        public AudioMixerGroup Out;
        public bool PlayOnAwake;
        public bool Loop;
        public AnimationCurve curve;
        [SerializeField]
        private float _maxDistance;
        public float MaxDistance
        {
            get => _maxDistance;
            set => _maxDistance = value < 0 ? 0 : value;
        }
        public float Volume
        {
            get => _volume;
            set => _volume = value < 0 ? 0 : value;
        }
        [SerializeField]
        private float _volume;
        public float SpetialBlend
        {
            get => _specialBlend;
            set => _specialBlend = value < 0 ? 0 : value > 1 ? 1 : value;
        }
        [SerializeField]
        private float _specialBlend;

        
        public void Play()
        {
            Source.outputAudioMixerGroup = Out;
            Source.clip = Clip;
            Source.Play();
        }
        public void Stop()
        {
            Source.Stop();
        }

    }
}

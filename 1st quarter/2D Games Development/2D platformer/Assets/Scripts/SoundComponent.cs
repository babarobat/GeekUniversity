using System;
using System.Collections;
using UnityEngine;


namespace Game.Audio
{
    /// <summary>
    /// Источник звука.
    /// Требует наличия компонента AudioSource.
    /// Расширяет возможности Audiosource.
    /// Управление полем Clip в компоненте AudioSource происходит отсюда.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    class SoundComponent : MonoBehaviour
    {
        
        /// <summary>
        /// Список звуков
        /// </summary>
        [Tooltip("Список звуков")]
        [SerializeField]        
        private AudioClip[] _sounds;
        /// <summary>
        /// Компонент Audiosource
        /// </summary>
        private AudioSource _source;
        /// <summary>
        /// Компонент Audiosource
        /// </summary>
        public AudioSource Source => _source;
        /// <summary>
        /// Громкость звука
        /// </summary>
        public float Volume
        {
            get => Source.volume;
            set => Source.volume = value < 0 ? 0 : value;
        }
        /// <summary>
        /// Скорость воспроизведения
        /// </summary>
        public float Pitch
        {
            get => Source.pitch;
            set => Source.pitch = value < -3 ? -3: value>3?3:value;
        }
        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            if (Source.playOnAwake && _sounds.Length > 0)
            {
                
                Source.clip = _sounds[0];
                Source.Play();
            }            
        }
        
        public void Play()
        {
            if (Source.clip != null)
            {
                Source.Play();
            }
            else
            {
                throw new Exception($"Choose sound to play on {name}");
            }
            
        }
       /// <summary>
       /// Воспроизодит кли с указанным именем
       /// </summary>
       /// <param name="name">Название клипа</param>
        public void Play(string name)
        {
            Source.clip = Array.Find(_sounds, s => s.name == name);
            Source.Play();

        }
        /// <summary>
        /// Останавливает воспроизведение
        /// </summary>
        public void Stop()
        {
            Source.Stop();
        }
        /// <summary>
        /// Источник еще воспроизводит звук?
        /// </summary>
        /// <returns></returns>
        public bool SourcePlaying() => Source.isPlaying;
        /// <summary>
        /// Играет ли звук с заданным именем
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        public bool SoundIsPlaying(string name) => Source.isPlaying && Array.Find(_sounds, s => s == Source.clip).name == name;
        /// <summary>
        /// Воспроизводит случайный звук из списка Sounds
        /// </summary>
        public void PlayRandomSound()
        {
            Source.clip = _sounds[UnityEngine.Random.Range(0, _sounds.Length)];
            Source.Play();
        }
        /// <summary>
        /// Поднимает громкость звука источника с 0 до установленного в значении Audioclip за указанный промежуток времени
        /// </summary>
        /// <param name="fadeTime">длительность фейда в секундах</param>
        private IEnumerator FadeInCor(float fadeTime)
        {
            var currentVol = Source.volume;
            float t = 0f;
            Source.volume = 0f;
            
            while (t <= fadeTime)
            {
                Source.volume = Mathf.Lerp(0f, currentVol, t / fadeTime);
                t += Time.deltaTime;
                yield return null;
            }
            Source.volume = currentVol;

        }
        /// <summary>
        /// Поднимает громкость звука источника с 0 до установленного в значении Audioclip за указанный промежуток времени
        /// </summary>
        /// <param name="fadeTime">длительность фейда в секундах</param>
        public void FadeIn(float fadeTime)
        {
            StartCoroutine(FadeInCor( fadeTime));
        }
        /// <summary>
        /// Опускает громкость звука источника до 0 за указанный промежуток времени
        /// </summary>
        /// <param name="fadeTime">длительность фейда в секундах</param>
        private IEnumerator FadeOutCor(float fadeTime)
        {            
            float t = 0f;
            float x = Source.volume;
            while (t <= fadeTime)
            {
                Source.volume = Mathf.Lerp(x, 0f, t / fadeTime);
                t += Time.deltaTime;
                yield return null;
            }
            Source.volume = 0f;   
        }
        /// <summary>
        /// Опускает громкость звука источника до 0 за указанный промежуток времени
        /// </summary>
        /// <param name="fadeTime">длительность фейда в секундах</param>
        public void FadeOut( float fadeTime)
        {
            StartCoroutine(FadeOutCor(fadeTime));
        }
        
    }
}

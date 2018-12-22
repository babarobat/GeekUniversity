using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Game.UI
{
    class OptionsMenu:MonoBehaviour
    {
        [SerializeField]
        private AudioMixer _master;
        [SerializeField]
        private Slider _fxSlider;
        [SerializeField]
        private Slider _musicSlider;


        private void Start()
        {
            _fxSlider.value = GetFxVolume();
            _musicSlider.value = GetMusicVolume();

        }
        public float GetFxVolume()
        {
            float value;
            _master.GetFloat("FxVolume", out value);
            return value;
        }
        public float GetMusicVolume()
        {
            float value;
            _master.GetFloat("MusicVolume", out value);
            return value;
        }
        public void SetFxVolume(float value)
        {
            value = value;
            _master.SetFloat("FxVolume", value);
        }
        public void SetMusicVolume(float value)
        {
            value = value;
            _master.SetFloat("MusicVolume", value);
        }
        public void SetSliderValu(Slider s, float value)
        {
            s.value = value;
        }

    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    class FlashLightView:MonoBehaviour
    {
        private Text _text;
        private void Start()
        {
            _text = GetComponentInChildren<Text>();
        }
        public float Text
        {
            set => _text.text = $"{ value:0.0}";
        }
        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}

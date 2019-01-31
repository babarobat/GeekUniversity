using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game.Audio;

namespace Game
{
    class ToolTipMessage:MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI _message;
        [SerializeField]
        Animator anim;
        bool _canShow = true;
        [SerializeField]
        SoundComponent _sound;
        
        public void  Show(string message)
        {
            if (_canShow)
            {
                _sound.Play("FX_NotEnoughEnergy");
                _message.text = message;
                anim.SetTrigger("Show");
                _canShow = false;
            }
        }
        void Hide()
        {
            anim.SetTrigger("Hide");
            _canShow = true;
        }
        
    }
}

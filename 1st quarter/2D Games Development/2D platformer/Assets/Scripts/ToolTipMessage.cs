using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    class ToolTipMessage:MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI _message;
        [SerializeField]
        Animator anim;
        bool _canShow = true;
        public void  Show(string message)
        {
            if (_canShow)
            {
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

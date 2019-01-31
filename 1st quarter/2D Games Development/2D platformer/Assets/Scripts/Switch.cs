using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Game.Controllers;
using Game.Audio;
namespace Game
{
    class Switch:MonoBehaviour
    {
        [SerializeField]
        SoundComponent _sound;
        Trigger trigger;
        Animator anim;

        private void Start()
        {            
            trigger = GetComponentInChildren<Trigger>();
            anim = GetComponentInChildren<Animator>();
            trigger.OnInteract += OnInteract;
        }
        void OnInteract(TriggerEventArgs e)
        {
            if (e.Sender.IsInteractble)
            {
                e.boolMeta = !e.boolMeta;
                _sound.Play("FX_Switch");
                anim.SetBool("On", e.boolMeta);
                
            }
            
           
        }

    }
}

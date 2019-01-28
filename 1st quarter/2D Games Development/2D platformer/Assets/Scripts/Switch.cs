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
        }
        void OnInteract(TriggerEventArgs e)
        {
            anim.SetBool("On", e.boolMeta);
        }

    }
}

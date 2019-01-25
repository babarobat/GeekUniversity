using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Game.Controllers;
namespace Game
{
    class Switch:MonoBehaviour
    {
        SoundController soundController;
        Trigger trigger;
        Animator anim;

        private void Start()
        {
            soundController = GetComponentInChildren<SoundController>();
            trigger = GetComponentInChildren<Trigger>();
            anim = GetComponentInChildren<Animator>();



        }
        void OnInteract(TriggerEventArgs e)
        {
            anim.SetBool("On", e.boolMeta);
        }

    }
}

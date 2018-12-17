using UnityEngine;
using Game.Controllers;

namespace Game
{
    class Uzi:BaseWeapon
    {
        private SoundController _soundController;
        protected override void Start()
        {
            _soundController = GetComponentInChildren<SoundController>();
        }
        protected override void PlayFireSound()
        {
            _soundController.PlaySound("Blaster",false);
        }    
    }
}

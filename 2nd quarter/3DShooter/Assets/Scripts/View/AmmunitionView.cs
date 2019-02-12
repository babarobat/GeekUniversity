using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    class AmmunitionView:MonoBehaviour
    {
        [SerializeField]
        private Text _name;
        [SerializeField]
        private Text _clipsCount;
        [SerializeField]
        private Text _bulletsCount;

        
        public void UpdateWeaponsView(int curBull, int maxBull, int currClip, int maxClip, string name)
        {
            _name.text = name;
            _clipsCount.text = $"обоймы:{currClip}/{maxClip}";
            _bulletsCount.text = $"патроны:{curBull}/{maxBull}";
        }
        public void ShowNoBulletsMess()
        {
            print("NoBullets");
        }
        public void ShowReloadMessage()
        {
            print("Reloading");
        }
        public void ShowNoClipsMessage()
        {
            print("NoClips");
        }
    }
}

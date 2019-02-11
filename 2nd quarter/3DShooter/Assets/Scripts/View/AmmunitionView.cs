using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    class AmmunitionView:MonoBehaviour
    {
        [SerializeField]
        private Text _clipBulletsCount;
        public void SetClipBullets(int clips, int bullets)
        {
            _clipBulletsCount.text = $"{clips}/{bullets}";
        }
    }
}

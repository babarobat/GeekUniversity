using Game.Interfaces;
    using UnityEngine;

namespace Game
{
    class DamagebleTest : MonoBehaviour, IDamageble
    {
        private float currentHealth = 100;
        
        public void GetDamage(DamageInfo damageInfo)
        {
            if (currentHealth>1)
            {
                currentHealth--;
                print($"обьъект {name} получил урон {damageInfo.Damage}. Текущее здоровье: { currentHealth }");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Game.Controllers;

namespace Game
{
    class UIManager:MonoBehaviour
    {
        [SerializeField]
        Text _healthBar;

        PlayerController _player;
        HealthController _playerHp;

        private void Start()
        {
            _playerHp = FindObjectOfType<PlayerController>().GetComponentInChildren< HealthController>();
            ChangeHp(_playerHp.CurrentHp);
            _playerHp.OnHpChange += ChangeHp;
        }
        void ChangeHp(int value)
        {
            _healthBar.text = value.ToString();
        }

    }
}

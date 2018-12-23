using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    class UIHealthController:BaseComponentController
    {
        [SerializeField]
        Text _healthBar;

        PlayerController _player;
        HealthController _playerHp;

        protected override void Start()
        {
            _playerHp = FindObjectOfType<PlayerController>().GetComponentInChildren<HealthController>();
            _healthBar.text = _playerHp.StartHp.ToString();
            _playerHp.OnHpChange += ChangeHp;
        }
        void ChangeHp(int value)
        {
            _healthBar.text = value.ToString();
        }
    }
}

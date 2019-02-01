using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        private Light _light;
        public Light Light => _light;
        private Transform _follow;
        private Vector3 _offset;
        public float BatteryChargeCurrent { get; private set; }
        [SerializeField] private float _moveSpeed = 10;
        [SerializeField] private float _batteryChargeMax;
        [SerializeField] private float _disсhargeSpeed;
        [SerializeField] private float _chargeSpeed;


        protected override void Awake()
        {
            base.Awake();
            _light = GetComponentInChildren<Light>();
            _follow = FindObjectOfType<Camera>().transform;
            _offset = transform.position - _follow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }

        public void Switch(bool value)
        {
            _light.enabled = value;
            if (!value) return;
            Transform.position = _follow.position + _offset;
            Transform.rotation = _follow.rotation;
        }
        public void Rotate()
        {
            if (!_light) return;
            print(_follow.position);
            Transform.position = _follow.position + _offset;
            Transform.rotation = Quaternion.Lerp(transform.rotation, _follow.rotation, _moveSpeed * Time.deltaTime);
        }
        public bool Disсharge()
        {
            if (BatteryChargeCurrent>0)
            {
                BatteryChargeCurrent -= Time.deltaTime* _disсhargeSpeed;
                return true;
            }
            return false;
        }
        public void Charge()
        {
            if (BatteryChargeCurrent <= _batteryChargeMax)
            {
                BatteryChargeCurrent += Time.deltaTime * _disсhargeSpeed;
            }
            
        }
    }
}

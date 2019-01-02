using System;
using System.Collections;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    class Lift:MonoBehaviour
    {
       
        [SerializeField]
        Vector2[] _stopPositions;
        int posIndex = 0;
        [SerializeField]
        float _speed;
        [SerializeField]
        Trigger[] _liftControlSwitches;
        [SerializeField]
        Trigger[] _liftEnergySwitches;

        int _currentEnergy = 0;

        CameraController _camcontroller;
        [SerializeField]
        Animator [] _lamps;
        [SerializeField]
        
        int _lampsIndex = 0;
        [SerializeField]
        ToolTipMessage _messagePannel;
        
        bool isWorking = false;
        private void Start()
        {
            
            foreach (var item in _lamps)
            {
                item.enabled = false;
            }
            _camcontroller = FindObjectOfType<CameraController>();
            transform.position = _stopPositions[0];
            foreach (var _switch in _liftControlSwitches)
            {
                _switch.IsInteractble = false;
                _switch.OnInteract += MoveLift;

            }
            foreach (var _switch in _liftEnergySwitches)
            {
               
                _switch.IsInteractble = true;
                _switch.OnInteract += AddEnergy;
            }

        }
        void MoveLift(TriggerEventArgs args)
        {

            if (!isWorking&& args.Sender.IsInteractble)
            {
                StartCoroutine(MoveNext());
            }
            if (!args.Sender.IsInteractble )
            {

                _messagePannel.Show("Not enough energy!");
            }
            
        }
        IEnumerator MoveNext()
        {
            float dist = 1;
            posIndex = posIndex < _stopPositions.Length - 1 ? posIndex + 1 : 0;
            isWorking = true;
            while (dist > 0.1)
            {
                var dir = _stopPositions[posIndex] -(Vector2)transform.position;
                dist = Vector2.Distance(transform.position, _stopPositions[posIndex]);
                transform.position += (Vector3)dir.normalized * _speed * Time.deltaTime;
                yield return null;
            }
            isWorking = false;
            transform.position =_stopPositions[posIndex];
        }
        void AddEnergy(TriggerEventArgs args)
        {
            _camcontroller.ShowPos(transform.position);
            
            _currentEnergy+=1;
            StartCoroutine(TurnOnLamp());
            if (_currentEnergy== _liftEnergySwitches.Length)
            {
                TernOnLift();
                
            }

        }
        void TernOnLift()
        {
            foreach (var _switch in _liftControlSwitches)
            {
                _switch.IsInteractble = true;
                _switch.OnInteract += MoveLift;
            }
        }
        IEnumerator TurnOnLamp()
        {
            yield return new WaitForSeconds(2f);
            _lamps[_lampsIndex].enabled = true;
            _lampsIndex++;
        }
        
        

    }
}

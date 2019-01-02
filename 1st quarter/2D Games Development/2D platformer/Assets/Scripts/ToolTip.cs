using UnityEngine;

namespace Game
{
    class ToolTip:MonoBehaviour
    {
        
        [SerializeField]
        private Trigger _showTrigger;

        private void Start()
        {
            _showTrigger.OnEnter += ShowToolTip;
            _showTrigger.OnExit += HideToolTip;
           _showTrigger.OnInteract += HideToolTip;
            gameObject.SetActive(false);
        }
        void ShowToolTip(TriggerEventArgs e)
        {
            gameObject.SetActive(true);
        }
        void HideToolTip(TriggerEventArgs e)
        {
            gameObject.SetActive(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    class GlobalGameManager:Singleton<GlobalGameManager>
    {
       [SerializeField]
        private GameStates _currentGameState;
        public GameStates CurrentState
        {
            get => _currentGameState;
            set
            {
                
                _currentGameState = value;
                OnStateChange?.Invoke(this._currentGameState);
            }
            
        }
        public Action<GameStates> OnStateChange;
        private void Start()
        {
            
            OnStateChange?.Invoke(this._currentGameState);
        }
        public void ChangeState(GameStates s)
        {
            CurrentState = s;
        }
    }
}

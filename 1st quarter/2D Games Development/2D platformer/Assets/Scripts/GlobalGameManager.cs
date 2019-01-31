using System;
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
                OnStateChange?.Invoke(_currentGameState);
            }
            
        }
        public Action<GameStates> OnStateChange;
        private void Start()
        {
            
            OnStateChange?.Invoke(_currentGameState);
        }
        public void ChangeState(GameStates s)
        {
            CurrentState = s;
        }
    }
}

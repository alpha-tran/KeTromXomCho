using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Game.Gameplay
{
    public class GameManager : Singleton<GameManager>
    {
        private StateMachine<GameManager> _stateMachine = new StateMachine<GameManager>();
        private GameplayState _gameplayState;

        private void Start()
        {
            _gameplayState = new GameplayState(this);
            _stateMachine.Initialize(_gameplayState);
        }
        private void Update()
        {
            _stateMachine.CurrentState.HandleInput();
            _stateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }
    }
}

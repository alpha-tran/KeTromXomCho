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
        private MainMenuState _mainMenuState;


        private void Start()
        {
            _gameplayState = new GameplayState(this);
            _mainMenuState = new MainMenuState(this);

            _stateMachine.Initialize(_mainMenuState);
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


        public void ChangeState(Enums.StateName stateName)
        {
            switch (stateName)
            {
                case Enums.StateName.MainMenu:
                    {
                        _stateMachine.ChangeState(_mainMenuState);
                        return;
                    }
                case Enums.StateName.Gameplay:
                    {
                        _stateMachine.ChangeState(_gameplayState);
                        return;
                    }
                default: return;
            }
        }
    }
}

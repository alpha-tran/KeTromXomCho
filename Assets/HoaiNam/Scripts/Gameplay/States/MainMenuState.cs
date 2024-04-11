using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Game.Gameplay
{
    public class MainMenuState : State<GameManager>
    {
        public MainMenuState(GameManager context) : base(context)
        {
        }

        public override void Enter()
        {
            UIManager.Instance?.ShowScreen<MainMenuScreen>(forceShowData: true);

            _context.Register(Enums.EventID.OnStartGame, StartGameOnClick);
        }

        public override void Exit()
        {
            base.Exit();
            _context.Unregister(Enums.EventID.OnStartGame, StartGameOnClick);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void StartGameOnClick(object data)
        {
            // start game
            _context.ChangeState(Enums.StateName.Gameplay);
        }
    }
}

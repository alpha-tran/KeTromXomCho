using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game.Gameplay
{
    public class GameplayState : State<GameManager>
    {
        public GameplayState(GameManager context) : base(context)
        {
        }

        public override void Enter()
        {
            UIManager.Instance?.HideAllScreens();
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }

        public override void Exit()
        {
            base.Exit();
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
    }

}

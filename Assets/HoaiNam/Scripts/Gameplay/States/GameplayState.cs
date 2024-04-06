using Game.UI;
using System;
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

            UIManager.Instance?.ShowOverlap<GameplayOverlap>(forceShowData: true);



            // register
            _context.Register(Enums.EventID.BackToMainMenu, GoToMainMenu);
        }

        private void GoToMainMenu(object obj)
        {
            _context.ChangeState(Enums.StateName.MainMenu);
            SceneManager.UnloadSceneAsync(1,UnloadSceneOptions.None);
        }

        public override void Exit()
        {
            base.Exit();
            foreach(var pool in ResourceManager.Instance.pools)
            {
                pool.DestroyAll();
            }
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

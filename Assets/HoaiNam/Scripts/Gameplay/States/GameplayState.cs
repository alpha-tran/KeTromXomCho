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
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            UIManager.Instance?.ShowOverlap<GameplayOverlap>(forceShowData: true);



            // register
            _context.Register(Enums.EventID.BackToMainMenu, GoToMainMenu);
            _context.Register(Enums.EventID.OnEndGame, OnEndGame);
            _context.Register(Enums.EventID.PlayAgain, PlayAgain);


        }


        public override void Exit()
        {
            base.Exit();
            foreach(var pool in ResourceManager.Instance.pools)
            {
                pool.DestroyAll();
            }
            _context.Unregister(Enums.EventID.BackToMainMenu, GoToMainMenu);
            _context.Unregister(Enums.EventID.OnEndGame, OnEndGame);
            _context.Unregister(Enums.EventID.PlayAgain, PlayAgain);
            SceneManager.UnloadSceneAsync(1);

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

        private void GoToMainMenu(object obj)
        {
            _context.ChangeState(Enums.StateName.MainMenu);
            SceneManager.UnloadSceneAsync(1, UnloadSceneOptions.None);
        }

        private void OnEndGame(object obj)
        {
            _context.StartCoroutine(OnEndGameCoroutine(obj));
        }

        private void PlayAgain(object obj)
        {
            _context.Broadcast(Enums.EventID.OnStartGame);
            _context.ChangeState(Enums.StateName.Gameplay);
        }

        private float _endGameDuration = 3f;
        IEnumerator OnEndGameCoroutine(object obj)
        {
            yield return new WaitForSeconds(_endGameDuration);
            UIManager.Instance?.HideAllOverlaps();
            UIManager.Instance?.ShowScreen<ResultScreen>(data: obj, forceShowData: true);
        }


    }

}

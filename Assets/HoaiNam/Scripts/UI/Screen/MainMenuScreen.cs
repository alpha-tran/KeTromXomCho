using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MainMenuScreen : BaseScreen
    {
        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _quitGameBtn;

        public override void Hide()
        {
            base.Hide();
            _startGameBtn.onClick.RemoveListener(StartBtnOnClick);
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Show(object data)
        {
            base.Show(data);
            _startGameBtn.onClick.AddListener(StartBtnOnClick);
        }

        private void StartBtnOnClick()
        {
            Debug.Log("broad cast");
            this.Broadcast(Enums.EventID.OnStartGame);
        }

    
    }
}

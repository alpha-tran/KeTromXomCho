using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Game.UI
{
    public class ResultScreen : BaseScreen
    {
        [SerializeField] private Button _playAgainBtn;
        [SerializeField] private Button _backToMenuBtn;
        [SerializeField] private TMP_Text _scoreTxt;



        public override void Hide()
        {
            base.Hide();
            _backToMenuBtn.onClick.RemoveListener(QuitToMenuOnClick);
            _playAgainBtn.onClick.RemoveListener(PlayAgainOnClick);
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Show(object data)
        {
            base.Show(data);
            int money = (int)data;
            if (money == 0) _scoreTxt.text = "0 k";
            else
            {
                _scoreTxt.text = money.ToString() + ".000 k";
            }
            _backToMenuBtn.onClick.AddListener(QuitToMenuOnClick);
            _playAgainBtn.onClick.AddListener(PlayAgainOnClick);
        }

        private void PlayAgainOnClick()
        {
            Hide();
            this.Broadcast(Enums.EventID.PlayAgain);
        }

        private void QuitToMenuOnClick()
        {
            Hide();
            this.Broadcast(Enums.EventID.BackToMainMenu);
        }
    }

}

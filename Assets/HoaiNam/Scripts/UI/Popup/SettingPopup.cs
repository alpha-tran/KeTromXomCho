using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.UI
{
    public class SettingPopup : BasePopup
    {
        [SerializeField] private Button _resumeGameBtn;
        [SerializeField] private Button _quitToMenuBtn;

        public override void Hide()
        {
            base.Hide();
            _resumeGameBtn.onClick.RemoveListener(ResumeGameOnClick);
            _resumeGameBtn.onClick.RemoveListener(QuitToMenuOnClick);
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Show(object data)
        {
            base.Show(data);
            _resumeGameBtn.onClick.AddListener(ResumeGameOnClick);
            _quitToMenuBtn.onClick.AddListener(QuitToMenuOnClick);

            PauseGame();

        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
        }

        private void QuitToMenuOnClick()
        {
            Time.timeScale = 1f;
            Hide();
            this.Broadcast(Enums.EventID.BackToMainMenu);
        }

        private void ResumeGameOnClick()
        {
            Time.timeScale = 1f;
            Hide();
        }
    }

}

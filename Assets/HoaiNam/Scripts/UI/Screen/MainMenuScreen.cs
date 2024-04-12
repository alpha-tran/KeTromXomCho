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
        [SerializeField] private Button _settingBtn;



        public override void Hide()
        {
            base.Hide();
            _startGameBtn.onClick.RemoveListener(StartBtnOnClick);
            _settingBtn.onClick.RemoveListener(SettingBtnOnClick);

        }

        public override void Init()
        {
            base.Init();
        }

        public override void Show(object data)
        {
            base.Show(data);
            _startGameBtn.onClick.AddListener(StartBtnOnClick);
            _settingBtn.onClick.AddListener(SettingBtnOnClick);

        }

        private void StartBtnOnClick()
        {
            Debug.Log("broad cast");
            this.Broadcast(Enums.EventID.OnStartGame);
        }

        private void SettingBtnOnClick()
        {
            UIManager.Instance?.ShowPopup<SettingPopup>(forceShowData: true);
        }
    }
}

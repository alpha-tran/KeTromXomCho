using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameplayOverlap : BaseOverlap
    {
        [SerializeField] private Button _settingBtn;
        [SerializeField] private TMP_Text _moneyTxt;



        public override void Hide()
        {
            base.Hide();
            this.Unregister(Enums.EventID.PlayerGainMoney, MoneyChange);

            _settingBtn.onClick.RemoveListener(SettingBtnOnClick);
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Show(object data)
        {
            base.Show(data);
            this.Register(Enums.EventID.PlayerGainMoney, MoneyChange);

            _settingBtn.onClick.AddListener(SettingBtnOnClick);

        }

        private void SettingBtnOnClick()
        {
            UIManager.Instance?.ShowPopup<SettingPopup>(forceShowData: true);
        }

        private void MoneyChange(object obj)
        {
            int money = (int)obj;
            _moneyTxt.text = money.ToString();
        }
    }
}


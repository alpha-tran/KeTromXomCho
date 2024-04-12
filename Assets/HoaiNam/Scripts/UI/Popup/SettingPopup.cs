using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using UnityEngine;
using UnityEngine.UI;


namespace Game.UI
{
    public class SettingPopup : BasePopup
    {
        [SerializeField] private Button _resumeGameBtn;
        [SerializeField] private Button _quitToMenuBtn;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;


        public override void Hide()
        {
            base.Hide();
            _resumeGameBtn.onClick.RemoveListener(ResumeGameOnClick);
            _resumeGameBtn.onClick.RemoveListener(QuitToMenuOnClick);
            _musicSlider.onValueChanged.RemoveListener(MusicSliderOnValueChanged);
            _sfxSlider.onValueChanged.RemoveListener(SfxSliderOnValueChanged);
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
            _musicSlider.onValueChanged.AddListener(MusicSliderOnValueChanged);
            _sfxSlider.onValueChanged.AddListener(SfxSliderOnValueChanged);

            _musicSlider.value = AudioManager.Instance.MusicVolume;
            _sfxSlider.value = AudioManager.Instance.SfxVolume;


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

        private void MusicSliderOnValueChanged(float value){
            this.Broadcast(Enums.EventID.MusicVolumeChanged, value);
        }

        private void SfxSliderOnValueChanged(float value){
            this.Broadcast(Enums.EventID.SfxVolumeChanged, value);
        }
    }

}

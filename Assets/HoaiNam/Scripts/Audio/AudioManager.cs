using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Game.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource _music;
        public float MusicVolume { get => _music.volume; }

        [SerializeField] AudioSource _sfx;
        public float SfxVolume { get => _sfx.volume; }

        [SerializeField] float _volumeOffset;

        [Header("Music")]
        [SerializeField] AudioClip _mainMenuMusic;
        [SerializeField] AudioClip _gameplayMusic;
        [SerializeField] AudioClip _showResultMusic;

        [Header("Sfx")]
        [SerializeField] AudioClip[] _playerHitTrap;
        [SerializeField] AudioClip[] _playerGainMoney;
        [SerializeField] AudioClip _playerDead;
        [SerializeField] AudioClip[] _playerJump;
        [SerializeField] AudioClip[] _playerLand;
        [SerializeField] AudioClip[] _playerGetOffFloor;


        private void Start()
        {
            _music.volume = 0.5f;
            _sfx.volume = 0.5f;
        }

        private void OnEnable()
        {
            RegisterEventIDs();
        }

        private void OnDisable()
        {
            this.Unregister(Enums.EventID.MusicVolumeChanged, ChangeMusicVolume);
            this.Unregister(Enums.EventID.SfxVolumeChanged, ChangeSfxVolume);


            this.Unregister(Enums.EventID.PlayerGainMoney, PlaySFXGainMoney);
            this.Unregister(Enums.EventID.PlayerHitTrap, PlaySFXHitTrap);
            this.Unregister(Enums.EventID.PlayerDead, PlaySFXEndGame);
            this.Unregister(Enums.EventID.PlayerJump, PlaySFXJump);
            this.Unregister(Enums.EventID.PlayerLand, PlaySFXLand);
            this.Unregister(Enums.EventID.PlayerGetOffFloor, PlaySFXGetOffFloor);

            this.Unregister(Enums.EventID.OnEndGame, PlayEndGameMusic);
            this.Unregister(Enums.EventID.BackToMainMenu, PlayMenuMusic);
            this.Unregister(Enums.EventID.OnStartGame, PlayGameplayMusic);

        }


        private void PlaySFXGainMoney(object data) => PlaySfx(_playerGainMoney[Random.Range(0, _playerGainMoney.Length - 1)]);
        private void PlaySFXHitTrap(object data) => PlaySfx(_playerHitTrap[Random.Range(0, _playerHitTrap.Length - 1)]);
        private void PlaySFXJump(object data) => PlaySfx(_playerJump[Random.Range(0, _playerJump.Length - 1)]);
        private void PlaySFXLand(object data) => PlaySfx(_playerLand[Random.Range(0, _playerLand.Length - 1)]);
        private void PlaySFXGetOffFloor(object data) => PlaySfx(_playerGetOffFloor[Random.Range(0, _playerGetOffFloor.Length - 1)]);
        private void PlaySFXEndGame(object data)
        {
            StartCoroutine(TurnDownMusicVolume());
            PlaySfx(_playerDead);
        }


        private void PlayEndGameMusic(object data)
        {
            _music.loop = false;
            _music.clip = _showResultMusic;
            _music.Play();
        }
        private void PlayMenuMusic(object data)
        {
            _music.loop = true;
            _music.clip = _mainMenuMusic;
            _music.Play();
        }
        private void PlayGameplayMusic(object data)
        {
            print("PlayGameplayMusic");
            _music.loop = true;
            _music.clip = _gameplayMusic;
            _music.Play();
        }




        private void PlaySfx(AudioClip sfx)
        {
            if (sfx != null)
            {
                float currentVolume = _sfx.volume;
                _sfx.volume += Random.Range(-_volumeOffset, _volumeOffset);
                _sfx.PlayOneShot(sfx);
                _sfx.volume = currentVolume;
            }
        }


        private float _turnDownMusicVolumeSpeed = 1f;
        private IEnumerator TurnDownMusicVolume()
        {
            float currentVolume = _music.volume;
            while (_music.volume > 0)
            {
                _music.volume = Mathf.Lerp(_music.volume, 0, _turnDownMusicVolumeSpeed * Time.deltaTime);
                if (_music.volume < 0.01)
                {
                    _music.volume = 0;
                    _music.volume = currentVolume;
                    break;
                }
                yield return null;
            }
        }

        private void ChangeMusicVolume(object obj)
        {
            _music.volume = (float)obj;
        }

        private void ChangeSfxVolume(object obj)
        {
            _sfx.volume = (float)obj;
        }



        public void RegisterEventIDs()
        {
            this.Register(Enums.EventID.MusicVolumeChanged, ChangeMusicVolume);
            this.Register(Enums.EventID.SfxVolumeChanged, ChangeSfxVolume);


            this.Register(Enums.EventID.PlayerGainMoney, PlaySFXGainMoney);
            this.Register(Enums.EventID.PlayerHitTrap, PlaySFXHitTrap);
            this.Register(Enums.EventID.PlayerDead, PlaySFXEndGame);
            this.Register(Enums.EventID.PlayerJump, PlaySFXJump);
            this.Register(Enums.EventID.PlayerLand, PlaySFXLand);
            this.Register(Enums.EventID.PlayerGetOffFloor, PlaySFXGetOffFloor);


            this.Register(Enums.EventID.OnEndGame, PlayEndGameMusic);
            this.Register(Enums.EventID.BackToMainMenu, PlayMenuMusic);
            this.Register(Enums.EventID.OnStartGame, PlayGameplayMusic);
        }

    }
}


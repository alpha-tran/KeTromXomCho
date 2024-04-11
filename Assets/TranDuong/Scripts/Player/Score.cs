
using Game.Gameplay;
using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Score : MonoBehaviour
{
	[SerializeField] private GameObject _coinVFX;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private PlayerOnePlatForm _playerOnePlatForm;
    [SerializeField] private PlayerJump _playerJump;


	[SerializeField] private int _currentScore = 0;


    private void OnEnable()
    {
		this.Register(Enums.EventID.PlayerGainMoney, OnGainMoney);
		this.Register(Enums.EventID.PlayerLoseMoney, OnLoseMoney);
        this.Register(Enums.EventID.PlayerDead, OnDead);
    }

    private void OnDisable()
    {
        this.Unregister(Enums.EventID.PlayerGainMoney, OnGainMoney);
        this.Unregister(Enums.EventID.PlayerLoseMoney, OnLoseMoney);
        this.Unregister(Enums.EventID.PlayerDead, OnDead);
    }



    private void OnTriggerEnter2D(Collider2D collision)
	{
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //	if (collision.gameObject.transform.position.x < transform.position.x)
        //	{
        //              OnGainMoney(collision.gameObject);
        //          }
        //          else if (collision.gameObject.transform.position.x > transform.position.x)
        //	{
        //              OnDead(collision.gameObject);
        //          }
        //}

        //if (collision.gameObject.CompareTag("PlusPoints"))
        //{

        //          OnGainMoney(collision.gameObject);
        //      }


        //      if (collision.gameObject.CompareTag("MinusPoints"))
        //{
        //          OnDead(collision.gameObject);
        //      }


        if (collision.gameObject.TryGetComponent(out IInteractable interactable))
		{
			interactable.DoInteract(this);
		}
        else
        {
            Debug.Log("cant get");
        }
    }

	private void VfxCoin() => _coinVFX.SetActive(true);
    private void VfxCameraShake() => StartCoroutine(_cameraShake.Shake(Camera.main, 0.2f, _playerOnePlatForm.SpeedDown * 0.005f));


    private void OnDead(object target)
	{
		Enemy enemy = target as Enemy;
        VfxCameraShake();
		_playerJump.enabled = false;
		transform.SetParent(enemy.transform.parent);
        this.Broadcast(Enums.EventID.OnEndGame, _currentScore);
    }

    private void OnGainMoney(object target)
	{
		Victim victim = target as Victim;
		VfxCoin();
		_currentScore += victim.Score;
        this.Broadcast(Enums.EventID.OnMoneyChanged, _currentScore);
    }

    private void OnLoseMoney(object target)
    {
        Trap trap = target as Trap;
        VfxCameraShake();
        _currentScore -= trap.MinusPoint;
        if(_currentScore < 0)
        {
            _currentScore = 0;
        }
        this.Broadcast(Enums.EventID.OnMoneyChanged, _currentScore);
    }

}


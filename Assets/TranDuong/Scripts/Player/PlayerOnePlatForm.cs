using System.Collections;
using UnityEngine;

public class PlayerOnePlatForm : MonoBehaviour
{

	[Header("Player Down")]
	[SerializeField] private float _speedDown;
	private GameObject _currentOneWayPlatfrom;
	[SerializeField] private CapsuleCollider2D _playerCollider;
	private Rigidbody2D _rb;


	[Header("VFX")]
	[SerializeField] private CameraShake _cameraShake;
	[SerializeField] private GameObject _smokeFx;


	private bool _ischeckShake = false;


	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{


			_rb.velocity = new Vector2(0f, -_speedDown);
			if (_currentOneWayPlatfrom != null)
			{
				StartCoroutine(DisableCollision());

			}

			_ischeckShake = true;

		}


	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("OneWayPlatform"))
		{
			_currentOneWayPlatfrom = collision.gameObject;
		}


		if (collision.gameObject.CompareTag("Floor"))
		{
			VfxSmoke();

			if (_ischeckShake)
			{
				_ischeckShake = false;
				VfxCameraShake();
			}

		}

	}


	private void OnCollisionExit2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("OneWayPlatform"))
		{
			_currentOneWayPlatfrom = null;
		}
	}


	public void VfxSmoke() => _smokeFx.SetActive(true);


	public void VfxCameraShake() => StartCoroutine(_cameraShake.Shake(Camera.main, 0.2f, _speedDown * 0.005f));



	private IEnumerator DisableCollision()
	{

		BoxCollider2D _platformCollider = _currentOneWayPlatfrom.GetComponent<BoxCollider2D>();

		Physics2D.IgnoreCollision(_playerCollider, _platformCollider);

		yield return new WaitForSeconds(1f);

		Physics2D.IgnoreCollision(_playerCollider, _platformCollider, false);


	}

}



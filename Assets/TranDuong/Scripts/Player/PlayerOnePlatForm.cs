using System.Collections;
using UnityEngine;

public class PlayerOnePlatForm : MonoBehaviour
{

	[Header("Player Down")]
	private GameObject _currentOneWayPlatfrom;
	[SerializeField] private CapsuleCollider2D _playerCollider;
    private Rigidbody2D _rb;


    [Header("Screen shaking")]
    [SerializeField] private float _speedDown;
    [SerializeField] private CameraShake _cameraShake;

	[SerializeField] private GameObject _smokeFx;


	private bool _ischeckShake = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) ) {


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


		if (collision.gameObject.CompareTag("Floor") && _ischeckShake)
		{
			StartCoroutine(_cameraShake.Shake(Camera.main, 0.2f, _speedDown * 0.005f));

            // smoke
            _smokeFx.SetActive(true);   

			_ischeckShake = false;
		}

	}

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            _currentOneWayPlatfrom = null;
        }
    }

    private IEnumerator DisableCollision()
    {
		
        BoxCollider2D _platformCollider = _currentOneWayPlatfrom.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(_playerCollider, _platformCollider);

        yield return new WaitForSeconds(1f);

        Physics2D.IgnoreCollision(_playerCollider, _platformCollider, false);


	}

}



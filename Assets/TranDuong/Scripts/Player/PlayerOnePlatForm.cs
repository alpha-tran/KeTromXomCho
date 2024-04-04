using System.Collections;
using UnityEngine;

public class PlayerOnePlatForm : MonoBehaviour
{


    private GameObject _currentOneWayPlatfrom;
	[SerializeField] private CapsuleCollider2D _playerCollider;
    private Rigidbody2D _rb;

    public bool _isCollider = false;

    [SerializeField] private float _speedDown;

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
           
        }
		
	}
 



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            _currentOneWayPlatfrom = collision.gameObject;
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



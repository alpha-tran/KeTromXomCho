using System.Collections;
using UnityEngine;

public class PlayerOnePlatForm : MonoBehaviour
{


    private GameObject _currentOneWayPlatfrom;
    [SerializeField] private CapsuleCollider2D _playerCollider;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) ) {

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

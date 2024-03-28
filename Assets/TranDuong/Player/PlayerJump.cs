using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private InputActionReference _jumpAction;
    [SerializeField] private CheckGround check;
    [SerializeField] private float _maxJumpCount;


    private float _lastJump = 0;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lastJump = _maxJumpCount;
    }

    // Update is called once per frame
    void  Update()
    {
        InputUpdateJump();
    }
    public void OnHitGround() => _lastJump = _maxJumpCount;
    private void InputUpdateJump()
    {

        if (_jumpAction.action.triggered && _lastJump > 0)
        {

            _rb.velocity = new Vector2(0f,_jumpForce); // Use AddForce and Vector2.up
            _lastJump --;

        }

    }
}

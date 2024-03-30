using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference _jumpAction;
    [Space(10)]

    [Header("Jumps")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxJumpCount;
    private float _lastJump;
    [Space(10)]

    [Header("CheckGround")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius;
    [SerializeField] private Transform _groundCheckTransform;

    

    private Rigidbody2D _rb;
    public bool _isGround { get; set; }
    public bool _isJumping { get; set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lastJump = _maxJumpCount;
        _isJumping = false;
    }


    void Update()
    {
        UpdateJump();
    }


    private void UpdateJump()
    {

        if (_jumpAction.action.triggered && _lastJump > 0) //nhận phím nhảy và thực hiện điều kiện số lần nhảy ko < 0 
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _lastJump--;
            _isJumping = true;

        }

        CheckGround();
    }


    public void CheckGround() // kiểm tra bằng thẻ layer nếu đúng thì true
    {
        _isGround = Physics2D.OverlapCircle(_groundCheckTransform.position, _radius, _layerMask);
        if (_isGround && !_rb.IsTouchingLayers(_layerMask) && _isJumping == true)
        {
            _lastJump = _maxJumpCount;
            _isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = true;

        }
    }
    private void OnDrawGizmos()// vẽ hình
    {
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawSphere(_groundCheckTransform.position, _radius);

    }
}

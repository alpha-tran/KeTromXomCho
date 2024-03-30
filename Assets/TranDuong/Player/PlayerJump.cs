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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lastJump = _maxJumpCount;
    }


    void Update()
    {
        UpdateJump();
    }


    private void UpdateJump()
    {

        if (_jumpAction.action.triggered && _lastJump > 0 )  //nhận phím nhảy và thực hiện điều kiện số lần nhảy ko < 0 
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _lastJump--;

        }

        CheckGround();
    }


    public void CheckGround() // kiểm tra bằng thẻ layer nếu đúng thì true
    {
        _isGround = Physics2D.OverlapCircle(_groundCheckTransform.position, _radius, _layerMask);
        if (_isGround && Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            _lastJump = _maxJumpCount;
        }
    }


    private void OnDrawGizmosSelected()// vẽ hình
    {
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawSphere(_groundCheckTransform.position, _radius);

    }
}

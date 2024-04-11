using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _defaultX = -7;
    [SerializeField] private float _movementSpeed;


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

    [Header("Vfx")]
    [SerializeField] private PlayerOnePlatForm _onePlatForm;


    private Rigidbody2D _rb;
    public bool IsGround { get; set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lastJump = _maxJumpCount;
    }


    void Update()
    {
        UpdateJump();
        UpdatePosition();

       
    }

    private void UpdatePosition()// update lại vị trí của player khi player bị collider đẩy đi
    {
        if(Mathf.Abs(transform.position.x - _defaultX) < Mathf.Epsilon)
        {
            transform.position = new Vector3(_defaultX, transform.position.y, transform.position.z);
            return;
        }
        float newX = Mathf.Lerp(transform.position.x, -7f, _movementSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void UpdateJump()
    {

        if (_jumpAction.action.triggered && _lastJump > 0 )  //nhận phím nhảy và thực hiện điều kiện số lần nhảy ko < 0 
        {
            this.Broadcast(Enums.EventID.PlayerJump);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _lastJump--;
            if (IsGround)
            {
                _onePlatForm.VfxSmokeJump();
			}
		}
        CheckGround();
    }


    public void CheckGround() // kiểm tra bằng thẻ layer nếu đúng thì true
    {
        IsGround = Physics2D.OverlapCircle(_groundCheckTransform.position, _radius, _layerMask);
        if (IsGround && Mathf.Abs(_rb.velocity.y) < 0.01f)// fix lỗi nhảy vô hạn
		{
            _lastJump = _maxJumpCount;
        }
    }


    private void OnDrawGizmosSelected()// vẽ hình
    {
        Gizmos.color = IsGround ? Color.green : Color.red;
        Gizmos.DrawSphere(_groundCheckTransform.position, _radius);

    }
}

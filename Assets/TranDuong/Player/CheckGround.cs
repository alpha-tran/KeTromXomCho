using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditorInternal.VersionControl.ListControl;

public class CheckGround : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius;
    [SerializeField] private UnityEvent _onHitGround;


    private bool _isGround { get; set; }
    private bool _lastState;

    void Update()
    {
        IsGrounded();
    }

    public void IsGrounded()
    {
        _isGround = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
        if (_isGround && _lastState == false)
        {
                _onHitGround.Invoke();
        }
        _lastState= _isGround;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, _radius);

    }
}

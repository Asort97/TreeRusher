using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _moveSpeed;


    private void FixedUpdate() {

        float _horizontal = _joystick.Horizontal;
        float _vertical = _joystick.Vertical;

        _rb.velocity = new Vector3(_horizontal * _moveSpeed, _rb.velocity.y, _vertical * _moveSpeed);

        if(_horizontal != 0f || _vertical != 0f)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            _anim.SetBool("isRun", true);
        }
        else
        {
            _anim.SetBool("isRun", false);
        }
    }

}

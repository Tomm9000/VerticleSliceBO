using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oriMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] bool _jumpPressed = false;
    [SerializeField] bool _canJump = false;
    [SerializeField] bool _canDoubleJump = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _canJump = true;
    }
    private void Update()
    {
        _jumpPressed = Input.GetButtonDown("Jump");
        if (_jumpPressed)
        {
            if (_canJump)
            {
                _rb.velocity = new Vector3(0, 10, 0);
                _canJump = false;
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                _rb.velocity = new Vector3(0, 10, 0);
                _canDoubleJump = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _canDoubleJump = true;
            Debug.Log("Reset double Jump");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _canJump = true;
        }
    }
}

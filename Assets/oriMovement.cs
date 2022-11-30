using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class oriMovement : MonoBehaviour
{
    private float health;

    private Rigidbody _rb;
    private bool _jumpPressed = false;
    private bool _canJump = false;
    private bool _canDoubleJump = false;
    private bool _doesWalk = false;

    [SerializeField] Camera _camera;
    private float _cameraSpeed = 5f;

    private float maxVelocity;

    [SerializeField] float speed = 5f;
    [SerializeField] float _jumpVelocity = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _canJump = true;
    }
    private void Update()
    {
        _doesWalk = Input.GetButton("Horizontal");
        //_rb.velocity += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed;
        _jumpPressed = Input.GetButtonDown("Jump");
        if (_doesWalk)
        {
            _rb.velocity += new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0) * Time.deltaTime;
        }
        if (_jumpPressed)
        {
            if (_canJump)
            {
                _rb.velocity += new Vector3(0, _jumpVelocity, 0) * Time.deltaTime;
                _canJump = false;
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                _rb.velocity += new Vector3(0, _jumpVelocity, 0) * Time.deltaTime;
                _canDoubleJump = false;
            }
            //else _jumpVelocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _canDoubleJump = true;
            Debug.Log("Reset double Jump");
        }
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, new Vector3(transform.position.x, transform.position.y, -10), _cameraSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _canJump = true;
        }
    }
    private void gainhealth(float amount)
    {
        health += amount;
    }

}

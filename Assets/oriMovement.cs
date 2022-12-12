using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oriMovement : MonoBehaviour
{

    // Double Jump Bools
    private Rigidbody _rb;
    //private bool _jumpPressed = false;
    private bool _canJump = false;
    private bool _canDoubleJump = false;
    //private bool _doesWalk = false;

    // Camera
    [SerializeField] Camera _camera;
    private float _cameraSpeed = 5f;

    // Movement Speed/Velocity
    //[SerializeField] float speed = 10f;
    [SerializeField] float _jumpVelocity = 5f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float acceleration = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _canJump = true;
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity += new Vector3(moveInput * maxSpeed, 0, 0) * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            if (_canJump)
            {
                _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
                _canJump = false;
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
                _canDoubleJump = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _canDoubleJump = true;
            Debug.Log("Reset double Jump");

            /*if (Input.GetKeyDown(KeyCode.V))
            {
                _rb.constraints = RigidbodyConstraints.FreezePosition;
                _rb.freezeRotation = false;
                if (Input.GetKeyUp(KeyCode.W))
                {

                    _rb.constraints = RigidbodyConstraints.None;
                    _rb.freezeRotation = true;
                    _rb.velocity = transform.forward * speed;
                }
            }*/
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rb.velocity += new Vector3(moveInput * maxSpeed * acceleration, 0, 0) * Time.deltaTime;
            }
        }
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, new Vector3(transform.position.x, transform.position.y, -10), _cameraSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
        Debug.Log("Reset Jump");
    }
}

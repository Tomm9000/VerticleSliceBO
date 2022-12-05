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

   
    [SerializeField] float speed = 5f;
    //[SerializeField] float _jumpVelocity = 0;
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
                _rb.velocity += new Vector3(0, 10, 0);
                _canJump = false;
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                _rb.velocity += new Vector3(0, 10, 0);
                _canDoubleJump = false;
            }
            //else _jumpVelocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _canDoubleJump = true;
            Debug.Log("Reset double Jump");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            _rb.constraints = RigidbodyConstraints.FreezePosition;
            _rb.freezeRotation = false;
            if (Input.GetKeyUp(KeyCode.W))
            {
               
                _rb.constraints = RigidbodyConstraints.None;
                _rb.freezeRotation = true;
                _rb.velocity = transform.forward * speed;
            }
        }
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

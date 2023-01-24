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

    // Animator stuffs
    public float animationSpeed = 3;
    public Animator animator;
    private Vector3 moveDirection = Vector3.zero;
    private bool animJumped;
    private bool animDbleJumped;

    //Other Scripts
    [SerializeField] UIElements _UIelements;

    //Orb Stuffs
    [SerializeField] GameObject _orb;
    [SerializeField] Transform _orbLocation;
    private float _orbSpeed = 5f;


    // Camera
    [SerializeField] Camera _camera;
    private float _cameraSpeed = 5f;

    // Movement Speed/Velocity
    //[SerializeField] float speed = 10f;
    [SerializeField] float _jumpVelocity = 5f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float acceleration = 5f;
    private float currentSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _canJump = true;
        _UIelements = GetComponent<UIElements>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity += new Vector3(moveInput * maxSpeed, 0, 0) * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {  
            var rotation = transform.rotation;
            rotation.SetLookRotation(moveDirection);
            transform.rotation = rotation;
        }

        // Animations
        if (moveInput == 1 || moveInput == -1) animator.SetBool("Walking", true);
        else animator.SetBool("Walking", false);

        if (Input.GetButtonDown("Jump"))
        {
            if (_canJump)
            {
                _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
                _canJump = false;
                _canDoubleJump = true;
                animJumped = true;
            }
            else if (_canDoubleJump)
            {
                _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
                _canDoubleJump = false;
                animDbleJumped = true;
            }

            //animations
            if (animJumped == true)
            {
                animator.SetBool("Jumping", true);
                animJumped = false;
            }
            else animator.SetBool("Jumping", false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _canDoubleJump = true;
            Debug.Log("Reset double Jump");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rb.velocity += new Vector3(moveInput * maxSpeed * acceleration, 0, 0) * Time.deltaTime;
            }
        }
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, new Vector3(transform.position.x, transform.position.y, -10), _cameraSpeed * Time.deltaTime);
        _orb.transform.position = Vector3.MoveTowards(_orb.transform.position, _orbLocation.transform.position, _orbSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
        //geef de lazer the tag lazer zo dat waarneer je er opvalt schiet je omhoog
        if (collision.gameObject.CompareTag("lazer"))
        {
            _rb.velocity += new Vector3(0, 10, 0);
            _UIelements.DoDamage();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallclimb : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] float maxSpeed = 20f;
    void Update()
    {
        
    }
    //deze code heb ik even apart gelecht - ruben
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("climbablewall"))
        {
            float moveInput = Input.GetAxisRaw("Vertical");
            _rb.velocity += new Vector3(moveInput * 0, maxSpeed, 0) * Time.deltaTime; 
            
        }
    }
    void OnTriggerStay(Collider other)
    {

        
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                //_rb.velocity = new Vector3(0, 10, 0);
                //transform.position += Vector3.up;
                //_rb.useGravity = false;
            }
        
    }
}
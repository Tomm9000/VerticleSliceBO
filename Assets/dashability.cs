using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashability : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] float timer;
    int dashabilitycounterright = 0;
    int dashabilitycounterleft = 0;
    Rigidbody rb_;
    float speed = 20;

    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            timer = 0.5f;
            dashabilitycounterright += 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            timer = 0.5f;
            dashabilitycounterleft += 1;
        }
        if (dashabilitycounterright == 2)
        {
            _rb.velocity = new Vector3(-15, 0, 0);
            //Vector3 move = new Vector3(-50,0,0);
            //rb_.MovePosition(transform.position + move * Time.deltaTime * speed);
             dashabilitycounterright = 0;
        }
        if (dashabilitycounterleft == 2)
        {
            _rb.velocity = new Vector3(15, 0, 0);
            //Vector3 move = new Vector3(50, 0, 0);
            //rb_.MovePosition(transform.position + move * Time.deltaTime * speed);
            dashabilitycounterleft = 0;
        }
        if (timer <= 0)
        {
            dashabilitycounterright = 0; 
            dashabilitycounterleft = 0;
        }
    }
}

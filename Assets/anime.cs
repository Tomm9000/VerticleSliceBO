using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    public float speed = 3;
    public Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("speed", 2);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("speed", 0);

        }


    }
}

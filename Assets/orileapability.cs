using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orileapability : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    
    
    void Update()
    {

        if (Input.GetKey(KeyCode.V))
        {
            _rb.velocity = new Vector3(0,15, 0);
        }





    }
    
}

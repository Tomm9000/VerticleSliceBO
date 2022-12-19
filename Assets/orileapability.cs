using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orileapability : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    bool ability = false;
    void Update()
    {
        
        if(ability == false)
        {
            if (Input.GetKey(KeyCode.V))
            {
                _rb.constraints = RigidbodyConstraints.FreezePosition;
                _rb.freezeRotation = false;
                ability = true;
            }
        }

        if(ability == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ability = false;

                _rb.constraints = RigidbodyConstraints.None;
                _rb.freezeRotation = true;
                _rb.velocity += new Vector3(0, 10, 0);

            }
        }
            
           
        
    }
    
}

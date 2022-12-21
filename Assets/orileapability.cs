using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orileapability : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    public bool ability = false;
    [SerializeField] Camera cam;
    Transform my;
    float speed = 100f;
    public GameObject player;

    void Awake()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
             
    }
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
            float camdis = cam.transform.position.y - my.position.y;

            Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camdis));
            float anglerad = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
            float angle = (360 / Mathf.PI) * anglerad;

            my.rotation = Quaternion.Euler(0, 0, angle);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                

                
                
                ability = false;

                _rb.constraints = RigidbodyConstraints.None;
                _rb.freezeRotation = true;
                transform.position += transform.forward * speed * Time.deltaTime;

            }
        }
            
           
        
    }
    
}

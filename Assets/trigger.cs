using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] GameObject escbutton;
    [SerializeField] private Rigidbody _rb;
        public Vector3 _movetoposition;
        public Vector3 _exittrigger;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "esctrigger")
        {
            escbutton.transform.position = _movetoposition;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("werkt");
                //hier moet nog een scenemanager
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "esctrigger")
        {
            escbutton.transform.position = _exittrigger;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] private Rigidbody _rb;
        
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "esctrigger")
        {
            button.SetActive(true);
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
            button.SetActive(false);
            
        }
    }
}

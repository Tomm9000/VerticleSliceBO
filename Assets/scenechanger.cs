using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    [SerializeField] bool menuload;
    void Update()
    {
        if(menuload == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("main menu");
                
            }
        }

    }
    public void mainmenu()
    {
        SceneManager.LoadScene("OriMovement");
    }
    
}

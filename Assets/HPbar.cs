using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPbar : MonoBehaviour
{
    [SerializeField] bool nostamina = true;
    [SerializeField] float hp;
    [SerializeField] float stamina;
    [SerializeField] TextMeshProUGUI hpdisplay;
    [SerializeField] TextMeshProUGUI staminadisplay;

    void Update()
    {
        hpdisplay.text = hp.ToString();
        staminadisplay.text = stamina.ToString();
        if(stamina < 10)
        {
            nostamina = false;
        }
        if(nostamina == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Health();
                Stamina();
            }
        }

    }
    void Health()
    {
        hp += 10;
    }
    void Stamina()
    {
        stamina -= 10;
    }
}

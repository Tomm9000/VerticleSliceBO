using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    [SerializeField] GameObject Energy;
    [SerializeField] GameObject Health;
    [SerializeField] int hp = 5;
    [SerializeField] int energy = 5;
    bool nostamina = true;
    [SerializeField] Vector3 spawnpoint;
    public void DoDamage()
    {
        hp --;
        Health.transform.GetChild(hp).gameObject.SetActive(false);
    }
    public void OnEnergyUse()
    {
        energy --;
        Energy.transform.GetChild(energy).gameObject.SetActive(false);
    }
    void Update()
    {
        if (energy < 0)
        {
            nostamina = false;
        }
        else if (energy > 0 || hp == 10)
        {
            nostamina = true;
        }
        if (hp >= 10)
        {
            nostamina = false;
        }
        else if (hp <= 9)
        {
            nostamina = true;
        }
        if (nostamina == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                _Health(1);
                Stamina();
            }
        }
        if(hp <= 0)
        {
            hp = 5;
            transform.position = spawnpoint;
        }
       
    }
    public void _Health(int HPchange)
    {
            hp += HPchange;
            DoDamage();
    }
    public void Stamina() 
    {
        energy -= 1;
        OnEnergyUse();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] GameObject Energy;
    [SerializeField] GameObject Health;
    [SerializeField] int hp = 5;
    [SerializeField] int energy = 5;
    bool nostamina = true;
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
                _Health();
                Stamina();
            }
        }
       
    }
    void _Health()
    {
        hp += 1;
        
    }
    void Stamina() 
    {
        energy -= 1;
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //geef de lazer the tag lazer zo dat waarneer je er opvalt schiet je omhoog
        if (collision.gameObject.CompareTag("lazer"))
        {
            hp -= 1;
            _rb.velocity = new Vector3(0, 10, 0);
        }
    }
}

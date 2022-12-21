using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPbar : MonoBehaviour
{
    [SerializeField] bool nostamina = true;
    [SerializeField] public int hp;
    [SerializeField] int maxhp;
    [SerializeField] int stamina;
    [SerializeField] HealthBar healthBar;
    private int damage = 1;
    [SerializeField] HealthBar staminaBar;


    void Start()
    {
        hp = maxhp;
        healthBar.SetMaxHealth(maxhp);
    }
    void Update()
    {

        if (stamina < 1)
        {
            nostamina = false;
        }
        else if(stamina > 0 && hp == 10)
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
                Health();
                Stamina();
            }
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            hp -= damage;
            healthBar.SetHealth(hp);
        }
          
    }
    void Health()
    {
        hp += 1;
        healthBar.SetHealth(hp);
    }
    void Stamina() //int amount
    {
        stamina -= 1;
        staminaBar.SetHealth(stamina);
    }
}

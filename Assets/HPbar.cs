using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    
    [SerializeField] public static int hp = 10;
    [SerializeField] int maxhp;
    [SerializeField] int stamina;
    [SerializeField] HealthBar healthBar;
    private int damage = 1;
    [SerializeField] HealthBar staminaBar;
    [SerializeField] int lazerDamage;
    [SerializeField] float timerforstamina;
    [SerializeField] bool nostamina = true;

    void Start()
    {
        hp = maxhp;
        healthBar.SetMaxHealth(maxhp);
    }
    void Update()
    {

        if (stamina < 0)
        {
            nostamina = false;
        }
        else if(stamina > 0 || hp == 10)
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
        timerforstamina -= Time.deltaTime;
        if(stamina <= 9)
        {
            if(timerforstamina <= 0)
            {
                stamina += 1;
                timerforstamina = 3f;
            }
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
    void OnCollisionEnter(Collision collision)
    {
        //geef de lazer the tag lazer zo dat waarneer je er opvalt schiet je omhoog
        if (collision.gameObject.CompareTag("lazer"))
        {
            HPbar.hp -= lazerDamage;
            healthBar.SetHealth(hp);
            _rb.velocity = new Vector3(0, 10, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerdamage : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] int lazerDamage;
    void OnCollisionEnter(Collision collision)
    {
        //geef de lazer the tag lazer zo dat waarneer je er opvalt schiet je omhoog
        if (collision.gameObject.CompareTag("lazer"))
        {
            HPbar.hp -= lazerDamage;
            _rb.velocity = new Vector3(0, 10, 0);
        }
    }
  
}

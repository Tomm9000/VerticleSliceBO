using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerdamage : MonoBehaviour
{
    [SerializeField] int lazerDamage;
    void OnCollisionEnter(Collision collision)
    {
        HPbar health = gameObject.GetComponent<HPbar>();
        health.hp -= lazerDamage;
        Debug.Log("werkt");
    }
}

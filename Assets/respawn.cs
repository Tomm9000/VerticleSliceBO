using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    [SerializeField] Vector3 spawnpoint;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("respawnground"))
        {
            transform.position = spawnpoint;
        }
    }
}

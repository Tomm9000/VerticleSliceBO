using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementscript : MonoBehaviour
{
    [SerializeField] private Rigidbody controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpHeight = 3f;

    Vector3 velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        //Vector3 move = transform.right * x;
        controller.velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed;
    }
}

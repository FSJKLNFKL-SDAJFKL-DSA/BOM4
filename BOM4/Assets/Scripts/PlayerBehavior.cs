using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    float movespeed;
    float movementX;
    float movementY;
    public float health;

    void Start()
    {
        health = 100;
        movespeed = 15f;
    }

    private void FixedUpdate()
    {
        Move();
    }


    //movement
    void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, 0f) * movespeed * Time.deltaTime;
        transform.position += new Vector3(0f, movementY) * movespeed * Time.deltaTime;

    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
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
    public float playerHealth;

    void Start()
    {
        playerHealth = 100;
        movespeed = 7f;
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

    void capSpeed()
    {

    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
    }
}
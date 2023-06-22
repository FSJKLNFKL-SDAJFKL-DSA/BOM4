using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float movespeed;
    float movementX;
    float movementY;
    public float playerHealth;

    // animator nesacities
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    void Start()
    {
        playerHealth = 100;
        movespeed = 7f;
    }

    //movement
    void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, 0f) * movespeed * Time.deltaTime;
        transform.position += new Vector3(0f, movementY) * movespeed * Time.deltaTime;

        // animator stuff
        //animator.SetFloat("Horizontal", movementX);
        //animator.SetFloat("Vertical", movementY);
        //animator.SetFloat("Speed", movement.magnitude); <--- does not work
    }

    void FixedUpdate()
    {
        Move();
    }

    void capSpeed()
    {

    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
    }
}
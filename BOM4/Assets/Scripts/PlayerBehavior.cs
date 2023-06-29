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
    public Animator animator;

    void Start()
    {
        playerHealth = 100;
        movespeed = 7f;
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, 0f) * movespeed * Time.deltaTime;
        transform.position += new Vector3(0f, movementY) * movespeed * Time.deltaTime;

        if (movementY == 1 || movementY == -1)
        {
            animator.SetFloat("Vertical", movementY);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetFloat("Vertical", 0);
            animator.SetBool("isMoving", false);

        }
        if (movementX == 1 || movementX == -1)
        {
            animator.SetFloat("Horizontal", movementX);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetBool("isMoving", false);

        }
    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
    }
}